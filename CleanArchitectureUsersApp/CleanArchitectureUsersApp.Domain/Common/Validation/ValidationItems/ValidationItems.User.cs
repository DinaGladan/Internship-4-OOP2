using CleanArchitectureUsersApp.Domain.Enumumerations.Validation;
using System.Xml;

namespace CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem NameMaxLength = new ValidationItem
            {
                Code = $"{CodePrefix}1",
                Message = $"Ime ne smije imat vise od {Entitis.Users.User.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationTy = ValidationTy.FormalValidation
            };
        }
    }
}
