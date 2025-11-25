using CleanArchitectureUsersApp.Domain.Enumumerations.Validation;

namespace CleanArchitectureUsersApp.Domain.Common.Validation
{
    public class ResultValidation
    {
        private List<ValidationItem> _validationItems = new List<ValidationItem>();
        public IReadOnlyList<ValidationItem> ValidationItems => _validationItems;
        public bool HasError
        {
            get
            {
                foreach (var valResult in _validationItems)
                {
                    if (valResult.ValidationSeverity == ValidationSeverity.Error)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool HasInfo => _validationItems.Any(valResult => valResult.ValidationSeverity == ValidationSeverity.Information);
        public bool HasWarning => _validationItems.Any(valResult => valResult.ValidationSeverity == ValidationSeverity.Warning);
        
        public void AddValidationItem(ValidationItem validationItem)
        {
            _validationItems.Add(validationItem);
        }
    }
}
