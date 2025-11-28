using CleanArchitectureUsersApp.Application.Mapping;
using CleanArchitectureUsersApp.Domain.Common.Validation;

namespace CleanArchitectureUsersApp.Api.Common
{
    public class Response<TValue> where TValue : class
    {
        public IReadOnlyList<ValidationItem> Infos { get; init; }
        public IReadOnlyList<ValidationItem> Warnings { get; init; }
        public IReadOnlyList<ValidationItem> Errors { get; init; }

        public TValue? Value { get; private set; }
        public Guid RequestId { get; private set; }

        public Response(ApplicationResult<TValue> result)
        {
            Infos = result.Infos;
            Warnings = result.Warnings;
            Errors = result.Errors;
            Value = result.Value;
            RequestId = result.RequestId;
        }
    }
}
