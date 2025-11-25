using CleanArchitectureUsersApp.Domain.Common.Validation;
using CleanArchitectureUsersApp.Domain.Common.Validation.ValidationItems;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureUsersApp.Domain.Entitis.Users
{
    public class User
    {
        public const int NameMaxLength = 100;
        public string Name { get; set; }
        public string Surname { get; set; } //unikatan
        public string Email { get; set; }   
        public string AddressStreet { get; set; }

        public string addressCity {  get; set; } 
        public string website { get; set; }
        public string password { get; set; } //inicijalni GUID spremit

         public async Task<ResultValidation> CreateOrUpdateValidation()
         {
            var validationResult = new ResultValidation(); 
            if (Name?.Length > NameMaxLength)
                validationResult.AddValidationItem(ValidationItems.User.NameMaxLength);

            return validationResult;
         }
    }
}
