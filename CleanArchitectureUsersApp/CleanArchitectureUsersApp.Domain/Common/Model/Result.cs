using CleanArchitectureUsersApp.Domain.Common.Validation;

namespace CleanArchitectureUsersApp.Domain.Common.Model
{
    public class Result<TValue>
    {
        public TValue Value { get; set; }
        public ResultValidation ResultValidation { get; set; }

        public Result(TValue value, ResultValidation resultValidation)
        {
            Value = value;
            ResultValidation = resultValidation;
        }
    }
}
