using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;
using FluentValidation;

namespace ApriCodeTestTask.BusinessLogic.Services.Games.Validation
{
    public partial class GameValidator : AbstractValidator<GameOperationRequest>
    {
        public GameValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(game => game.Name).NotEmpty();
            RuleFor(game => game.DeveloperId)
                .SetAsyncValidator(new GameDeveloperValidator(unitOfWork));
        }
    }
}