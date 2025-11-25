using CleanArchitectureUsersApp.Domain.Abstractions.Common;
using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;
using CleanArchitectureUsersApp.Domain.ValueObjects;

namespace CleanArchitectureUsersApp.Domain.Entitis.Users
{
    public class User : BaseEntity
    {
        public const int NameMaxLength = 100;
        public const int StreetAddressMaxLength = 150;
        public const int CityAddressMaxLength = 100;
        public const int WebsiteMaxLength = 100;
        public string Name { get; set; }
        public string Surname { get; set; } //unikatan
        public string Email { get; set; }   //unikatan
        public string AddressStreet { get; set; }
        public string addressCity {  get; set; } 
        public Location Location { get; set; }
        public string? Website { get; set; }
        public string password { get; set; } //inicijalni GUID spremit, app
        public bool IsActive { get; set; } = true;


        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        bool IsValidURL(string web_url)
        {
            if (Uri.TryCreate(web_url, UriKind.Absolute, out _))
                return true;
            return false;
        }

        public async Task<Result<bool>> Create(IUserUnitOfWork userUnitOfWork)
        {
            var result_validation = await CreateOrUpdateValidation();
            if (result_validation.HasError)
                return new Result<bool>(false, result_validation); // vracamo mu result_validation da bi onda poslije u app sloju predali korisniku

            await userUnitOfWork.Users.InsertAsync(this);
            await userUnitOfWork.SaveChangesAsync();

            return new Result<bool>(true, result_validation);
        }

        public async Task<ResultValidation> CreateOrUpdateValidation()
         {

            //stavili da je async u slucaju da imamo provjeru s nekakvim povezanim entitetima
            //pa cemo imat await company repository.getById ili nesto slicno, pa tu provjeravamo je li postoji kompanija koja se ide dodat na user
            var validationResult = new ResultValidation();
            if (string.IsNullOrEmpty(Name))
                validationResult.AddValidationItem(ValidationItems.User.NameRequired);
            if (Name?.Length > NameMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.NameMaxLength);
            if (string.IsNullOrEmpty(Surname))
                validationResult.AddValidationItem(ValidationItems.User.SurnameRequired);
            if (string.IsNullOrEmpty(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailRequired);
            if (!IsValidEmail(Email))
                validationResult.AddValidationItem(ValidationItems.User.EmailFormat);
            if (string.IsNullOrEmpty(AddressStreet))
                validationResult.AddValidationItem(ValidationItems.User.StreetAddressRequired);
            if (AddressStreet?.Length > StreetAddressMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.StreetAddressMaxLength);
            if (string.IsNullOrEmpty(addressCity))
                validationResult.AddValidationItem(ValidationItems.User.CityAddressRequired);
            if (addressCity?.Length > CityAddressMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.CityAddressMaxLength);
            if (Location.geoLat == null)
                validationResult.AddValidationItem(ValidationItems.User.GeoLatRequired);
            if (!Location.IsValidLat())
                validationResult.AddValidationItem(ValidationItems.User.GeoLatInvalid);
            if (Location.geoLng == null)
                validationResult.AddValidationItem(ValidationItems.User.GeoLngRequired);
            if (!Location.IsValidLng())
                validationResult.AddValidationItem(ValidationItems.User.GeoLngInvalid);
            if (!string.IsNullOrWhiteSpace(Website))
            {
                if (!IsValidURL(Website))
                    validationResult.AddValidationItem(ValidationItems.User.WebsiteInvalid);
                if(Website?.Length > WebsiteMaxLength)
                    validationResult.AddValidationItem(ValidationItems.User.WebsiteMaxLength);
            }
            return validationResult;
         }
    }
}
