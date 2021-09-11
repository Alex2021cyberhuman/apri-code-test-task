using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;
using FluentValidation;
using FluentValidation.Validators;

namespace ApriCodeTestTask.BusinessLogic.Services.Games.Validation
{
    public partial class GameValidator
    {
        private class GameDeveloperValidator :
            AsyncPropertyValidator<GameOperationRequest, Guid>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GameDeveloperValidator(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public override async Task<bool> IsValidAsync(
                ValidationContext<GameOperationRequest> context,
                Guid developerId,
                CancellationToken cancellation)
            {
                var developer =
                    await _unitOfWork.Developers.FindByIdAsync(developerId,
                        cancellation);
                return developer is not null;
            }

            protected override string GetDefaultMessageTemplate(
                string errorCode) =>
                "{PropertyName} should be exists";

            public override string Name => nameof(GameDeveloperValidator);
        }
    }
}