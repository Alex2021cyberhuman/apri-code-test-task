using System.Collections.Generic;
using FluentValidation;

namespace ApriCodeTestTask.BusinessLogic.Shared.Validation
{
    public class SharedValidator<T> : AbstractValidator<T>
    {
        public SharedValidator(IEnumerable<IValidator<T>> validators)
        {
            var selfRule = RuleFor(item => item);
            foreach (var validator in validators)
                selfRule.SetValidator(validator);
        }
    }
}