using CleanArchitectureUsersApp.Domain.Enumumerations.Validation;

namespace CleanArchitectureUsersApp.Domain.Common.Validation
{
    public class ValidationItem
    {
        public ValidationSeverity ValidationSeverity { get; set; } 
        public ValidationTy ValidationTy { get; init; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
