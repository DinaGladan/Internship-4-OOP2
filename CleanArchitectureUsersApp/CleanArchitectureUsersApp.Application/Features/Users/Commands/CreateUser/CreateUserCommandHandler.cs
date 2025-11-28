using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.Services;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;
using CleanArchitectureUsersApp.Domain.Entitis.Users;
using CleanArchitectureUsersApp.Domain.ValueObjects;

namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserUniqueness _userUniqueness;
        private readonly IUserUnitOfWork _userUnitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUserUniqueness userUniqueness, IUserUnitOfWork userUnitOfWork)
        {
            _userRepository = userRepository;
            _userUniqueness = userUniqueness;
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<Result<bool>> Handle(CreateUserCommand command)
        {
            var req = command.Request;

            var user = new User
            {
                Name = req.Name,
                Username = req.Username,
                Email = req.Email,
                AddressStreet = req.AddressStreet,
                addressCity = req.AddressCity,
                Location = new Location
                {
                    geoLat = req.GeoLat,
                    geoLng = req.GeoLng,
                },
                Website = req.Website,
                password = Guid.NewGuid().ToString(),
                IsActive = true

            };
            var validationResult = await user.CreateOrUpdateValidation();

            if (!await _userUniqueness.IsEmailUniqueAsync(user.Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailUnique);
            if(!await _userUniqueness.IsSurnameUniqueAsync(user.Username))
                validationResult.AddValidationItem(ValidationItems.User.UsernameUnique);

            var all_users = await _userRepository.GetAllAsync();
            if (all_users?.Values != null)
            {
                foreach (var existingUser in all_users.Values)
                {
                    if (existingUser.Location == null)
                        continue;
                    
                    if (existingUser.Location.Distance(user.Location) < 3)
                    {
                        validationResult.AddValidationItem(ValidationItems.User.DistanceInvalid);
                        break;
                    }
                    
                }
            }
            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);

            await _userRepository.InsertAsync(user);
            await _userUnitOfWork.SaveChangesAsync();
            return new Result<bool>(true, validationResult);
        }
    }
}
