using CleanArchitectureUsersApp.Application.Abstraction.Cashing;
using CleanArchitectureUsersApp.Application.Abstraction.External;
using CleanArchitectureUsersApp.Application.DTOs.ExternalDTO;
using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.Services;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;
using CleanArchitectureUsersApp.Domain.Entitis.Users;
using CleanArchitectureUsersApp.Domain.ValueObjects;

namespace CleanArchitectureUsersApp.Application.Features.Users.Commands.GetExternalUser
{
    public class GetExternalUserCommandHandler
    {

        private readonly IExternalService _externalService;
        private readonly ICacheService _cacheService;
        private readonly IUserRepository _userRepository;
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IUserUniqueness _userUniqueness;

        private const string CacheKey = "ExternalUsersCache";

        public GetExternalUserCommandHandler(IExternalService externalService, ICacheService cacheService, IUserRepository userRepository, IUserUnitOfWork userUnitOfWork, IUserUniqueness userUniqueness)
        {
            _externalService = externalService;
            _cacheService = cacheService;
            _userRepository = userRepository;
            _userUnitOfWork = userUnitOfWork;
            _userUniqueness = userUniqueness;
        }

        public async Task<Result<int>> Handle()
        {

            List<ExternalUser> externalUsers;
            externalUsers = await _cacheService.GetAsync<List<ExternalUser>>(CacheKey);
             

            if (externalUsers == null)
            {
                externalUsers = await _externalService.GetExternalUsersAsync();
                var date = DateTime.Now;
                DateTime endOfDay = DateTime.Today.AddDays(1);
                await _cacheService.SetAsync(CacheKey, externalUsers, endOfDay);
            }

            var allUsers = await _userRepository.GetAllAsync();
            int importedUsers = 0;
            var validation = new ResultValidation();
            foreach(var extUser in externalUsers)
            {   
                string website = extUser.Website;
                if (!string.IsNullOrWhiteSpace(website))
                    website = $"https://{website}";

                string address = extUser.AddressStreet;
                if (string.IsNullOrWhiteSpace(address))
                    address = "Street Address";

                string city = extUser.AddressCity;
                if (string.IsNullOrWhiteSpace(city))
                    city = "City";

                var user = new User
                {
                    Name = extUser.Name,
                    Username = extUser.Username,
                    Email = extUser.Email,
                    AddressStreet = address,
                    addressCity = city,
                    Location = new Location
                    {
                        geoLat = extUser.GeoLat,
                        geoLng = extUser.GeoLng,
                    },
                    Website = website,
                    password = Guid.NewGuid().ToString(),
                    IsActive = true
                };
                var validationResult = await user.CreateOrUpdateValidation();

                if (!await _userUniqueness.IsEmailUniqueAsync(user.Email))
                    validationResult.AddValidationItem(ValidationItems.User.EmailUnique);
                if (!await _userUniqueness.IsSurnameUniqueAsync(user.Username))
                    validationResult.AddValidationItem(ValidationItems.User.UsernameUnique);

                if (allUsers?.Values != null)
                {
                    foreach (var existingUser in allUsers.Values)
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
                if (!validationResult.HasError)
                {
                    await _userRepository.InsertAsync(user);
                    importedUsers++;

                }
                else
                {
                    foreach(var item in validationResult.ValidationItems)
                        validation.AddValidationItem(item);
                }
            }
            await _userUnitOfWork.SaveChangesAsync();
            return new Result<int>(importedUsers, validation);
        }

    }
}
