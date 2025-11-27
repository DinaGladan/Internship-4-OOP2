using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.Services;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;
using CleanArchitectureUsersApp.Domain.ValueObjects;

namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserUniqueness _userUniqueness;
        private readonly IUserUnitOfWork _userUnitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUserUniqueness userUniqueness, IUserUnitOfWork userUnitOfWork)
        {
            _userRepository = userRepository;
            _userUniqueness = userUniqueness;
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateUserCommand command)
        {
            var req = command.Request;

            var user = await _userRepository.GetByIdAsync(req.Id);
            if (user == null)
            {
                var validation = new ResultValidation();
                validation.AddValidationItem(ValidationItems.User.UserInvalidById);
                return new Result<bool>(false, validation);
            }

            user.Name = req.Name;
            user.Username = req.Username;
            user.Email = req.Email;
            user.AddressStreet = req.AddressStreet;
            user.addressCity = req.AddressCity;
            user.Location = new Location
            {
                geoLat = req.GeoLat,
                geoLng = req.GeoLng,
            };
            user.Website = req.Website;

            var validationResult = await user.CreateOrUpdateValidation();

            if (!await _userUniqueness.IsEmailUniqueAsync(user.Email, user.Id))
                validationResult.AddValidationItem(ValidationItems.User.EmailUnique);
            if (!await _userUniqueness.IsSurnameUniqueAsync(user.Username, user.Id))
                validationResult.AddValidationItem(ValidationItems.User.UsernameUnique);

            var all_users = await _userRepository.GetAllAsync();
            if (all_users?.Values != null)
            {
                foreach (var existingUser in all_users.Values)
                {
                    if (existingUser.Id == user.Id)
                        continue;
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

            await _userRepository.UpdateAsync(user);
            await _userUnitOfWork.SaveChangesAsync();
            return new Result<bool>(true, validationResult);
        }
    }
}
