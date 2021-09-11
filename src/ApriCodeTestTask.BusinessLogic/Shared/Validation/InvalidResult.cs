using ApriCodeTestTask.Core.Models.Results;
using FluentValidation.Results;

namespace ApriCodeTestTask.BusinessLogic.Shared.Validation
{
    public class InvalidResult<T> : ExecutionResult<T>
    {
        public InvalidResult(ValidationResult validationResult) : base(default,
            ExecutionStatus.BadRequest)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; set; }
    }
}