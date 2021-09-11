using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models;
using ApriCodeTestTask.Core.Entities;
using FluentValidation;

namespace ApriCodeTestTask.BusinessLogic.Services.Developers.Validation
{
    public class
        DeveloperValidator : AbstractValidator<DeveloperOperationRequest>
    {
        public DeveloperValidator()
        {
            RuleFor(developer => developer.Name).NotEmpty();
        }
    }
}