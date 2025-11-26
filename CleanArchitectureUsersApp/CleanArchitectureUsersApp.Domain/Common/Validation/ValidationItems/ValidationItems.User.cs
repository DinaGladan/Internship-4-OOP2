using CleanArchitectureUsersApp.Domain.Enumumerations.Validation;

namespace CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem NameRequired = new ValidationItem
            {
                Code = $"{CodePrefix}1",
                Message = "Ime je obavezno!",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };

            public static readonly ValidationItem NameMaxLength = new ValidationItem
            {
                Code = $"{CodePrefix}2",
                Message = $"Ime ne smije imat vise od {Entitis.Users.User.NameMaxLength} znakova.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            
            public static readonly ValidationItem UsernameRequired = new ValidationItem
            {
                Code = $"{CodePrefix}3",
                Message = "Username je obavezan! ",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem EmailRequired = new ValidationItem
            {
                Code = $"{CodePrefix}4",
                Message = "Email je obavezan.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem EmailFormat = new ValidationItem
            {
                Code = $"{CodePrefix}5",
                Message = "Email format nje zadovoljavajuc.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem StreetAddressRequired = new ValidationItem
            {
                Code = $"{CodePrefix}6",
                Message = "Adresa je obavezna.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem StreetAddressMaxLength = new ValidationItem
            {
                Code = $"{CodePrefix}7",
                Message = $"Adresa ne smije imat vise od {Entitis.Users.User.StreetAddressMaxLength} znakova.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem CityAddressRequired = new ValidationItem
            {
                Code = $"{CodePrefix}8",
                Message = "Grada adrese je obavezan.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem CityAddressMaxLength = new ValidationItem
            {
                Code = $"{CodePrefix}9",
                Message = $"Grad adrese ne smije imat vise od {Entitis.Users.User.CityAddressMaxLength} znakova.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem GeoLatRequired = new ValidationItem
            {
                Code = $"{CodePrefix}10",
                Message = "Geografska sirina je obavezna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem GeoLatInvalid = new ValidationItem
            {
                Code = $"{CodePrefix}11",
                Message = "Geografska sirina je broj izmedju -90 i 90",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem GeoLngRequired = new ValidationItem
            {
                Code = $"{CodePrefix}12",
                Message = "Geografska duljina je obavezna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem GeoLngInvalid = new ValidationItem
            {
                Code = $"{CodePrefix}13",
                Message = "Geografska duljina je broj izmedju -180 i 180",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem WebsiteInvalid = new ValidationItem
            {
                Code = $"{CodePrefix}14",
                Message = "URL stranice nije validan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem WebsiteMaxLength = new ValidationItem
            {
                Code = $"{CodePrefix}15",
                Message = $"Stranica ima veci broj znakova od dozvoljenih {Entitis.Users.User.WebsiteMaxLength}",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem EmailUnique = new ValidationItem
            {
                Code = $"{CodePrefix}16",
                Message = "Email treba bit unikatan.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.BusinessRule
            };
            public static readonly ValidationItem UsernameUnique = new ValidationItem
            {
                Code = $"{CodePrefix}17",
                Message = "Username treba bit unikatan. ",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.BusinessRule
            };
            public static readonly ValidationItem DistanceInvalid = new ValidationItem
            {
                Code = $"{CodePrefix}18",
                Message = "Udaljenost izmedju dva usera treba bit veca od 3km. ",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.BusinessRule
            };
        }
    }
}
