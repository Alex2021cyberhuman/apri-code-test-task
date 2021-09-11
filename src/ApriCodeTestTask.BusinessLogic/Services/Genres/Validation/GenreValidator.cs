using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.Models;
using FluentValidation;

namespace ApriCodeTestTask.BusinessLogic.Services.Genres.Validation
{
    public class GenreValidator : AbstractValidator<GenreOperationRequest>
    {
        public GenreValidator()
        {
            RuleFor(genre => genre.Name).NotEmpty();
        }
    }
}