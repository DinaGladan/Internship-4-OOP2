using CleanArchitectureUsersApp.Domain.Enumumerations.Validation;

namespace CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Company
        {
            public static string CodePrefix = nameof(Company);
            public static readonly ValidationItem CompanyNameRequired = new ValidationItem
            {
                Code = $"{CodePrefix}1",
                Message = "Ime kompanije je obavezno!",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };

            public static readonly ValidationItem NameMaxLength = new ValidationItem
            {
                Code = $"{CodePrefix}2",
                Message = $"Ime kompanije ne smije imat vise od {Entitis.Company.CompanyNameMaxLength} znakova.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
            public static readonly ValidationItem CompanyNameUnique = new ValidationItem
            {
                Code = $"{CodePrefix}3",
                Message = "Ime kompanije treba bit unikatno.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.BusinessRule
            };
            public static readonly ValidationItem CompanyInvalidById = new ValidationItem
            {
                Code = $"{CodePrefix}4",
                Message = "Ime kompanije s tim IDiem ne postoji.",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.BusinessRule
            };
        }
    }
}
