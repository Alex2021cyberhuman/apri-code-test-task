using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Models.Results;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games
{
    public interface IGamesService
    {
        Task<ExecutionResult<GameViewModel>> FindGameAsync(Guid id,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GameViewModel>> CreateGameAsync(
            GameCreateRequest request,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GameViewModel>> UpdateGameAsync(
            GameUpdateRequest request,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GamesListViewModel>> GetAllGamesAsync(
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GamesListViewModel>> GetAllGamesOfGenreAsync(
            Guid genreId,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GameViewModel>> AddGameToGenreAsync(
            Guid gameId, Guid genreId,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<GameViewModel>> RemoveGameFromGenreAsync(
            Guid gameId, Guid genreId,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<Nothing>> DeleteGameAsync(
            Guid id, CancellationToken cancellationToken = default);
    }
}