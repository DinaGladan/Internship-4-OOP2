using CleanArchitectureUsersApp.Domain.Abstractions.Common;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;

namespace CleanArchitectureUsersApp.Domain.Entitis
{
    public class Company :BaseEntity
    {
        public const int CompanyNameMaxLength = 150;
        public string CompanyName { get; set; } //uniqe

        public async Task<ResultValidation> CreateOrUpdateValidation()
        {
            var validationResult = new ResultValidation();
            if (string.IsNullOrEmpty(CompanyName))
                validationResult.AddValidationItem(ValidationItems.Company.CompanyNameRequired);
            if (CompanyName.Length > CompanyNameMaxLength)
                validationResult.AddValidationItem(ValidationItems.Company.NameMaxLength);

            return validationResult;
        }

    }
}
