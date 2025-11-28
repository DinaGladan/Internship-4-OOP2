using CleanArchitectureUsersApp.Domain.Common.Model;
using CleanArchitectureUsersApp.Domain.Common.Validation;

namespace CleanArchitectureUsersApp.Application.Mapping
{
    public class ApplicationResult<T> where T : class
    {
        public IReadOnlyList<ValidationItem> Infos { get; init; }
        public IReadOnlyList<ValidationItem> Warnings { get; init; }
        public IReadOnlyList<ValidationItem> Errors { get; init; }
        public T? Value { get; init; }
        public Guid RequestId { get; init; }

        public bool HasError => Errors != null && Errors.Any();
        public ApplicationResult(Result<T> domainResult)
        {
            Value = domainResult.Value;
            RequestId = Guid.NewGuid();

            Infos = domainResult.ResultValidation.ValidationItems
                .Where(x => x.ValidationSeverity == Domain.Enumumerations.Validation.ValidationSeverity.Information)
                .ToList();

            Warnings = domainResult.ResultValidation.ValidationItems
                .Where(x => x.ValidationSeverity == Domain.Enumumerations.Validation.ValidationSeverity.Warning)
                .ToList();

            Errors = domainResult.ResultValidation.ValidationItems
                .Where(x => x.ValidationSeverity == Domain.Enumumerations.Validation.ValidationSeverity.Error)
                .ToList();
        }
    }
}
