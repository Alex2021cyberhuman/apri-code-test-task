using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.Models;
using ApriCodeTestTask.Core.Models.Results;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres
{
    public interface IGenresService
    {
        Task<ExecutionResult<GenreViewModel>> FindGenreAsync(Guid id,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GenreViewModel>> CreateGenreAsync(
            GenreCreateRequest request,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GenreViewModel>> UpdateGenreAsync(
            GenreUpdateRequest request,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GenresListViewModel>> GetAllGenresAsync(
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<Nothing>> DeleteGenreAsync(
            Guid id, CancellationToken cancellationToken = default);
    }
}