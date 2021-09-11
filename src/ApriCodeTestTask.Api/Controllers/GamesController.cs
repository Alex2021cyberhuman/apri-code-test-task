using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Api.Extensions;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApriCodeTestTask.Api.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetGame(Guid id,
            CancellationToken cancellationToken)
        {
            return await _gamesService.FindGameAsync(id, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetGames(
            CancellationToken cancellationToken)
        {
            return await _gamesService.GetAllGamesAsync(cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostGame(
            GameCreateRequest request, CancellationToken cancellationToken)
        {
            return await _gamesService
                .CreateGameAsync(request, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutGame(Guid id,
            GameUpdateRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            return await _gamesService
                .UpdateGameAsync(request, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGame(Guid id,
            CancellationToken cancellationToken)
        {
            return await _gamesService.DeleteGameAsync(id, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPost("{gameId:guid}/genres/{genreId:guid}")]
        public async Task<IActionResult> PostGameToGenre(
            Guid gameId, Guid genreId, CancellationToken cancellationToken)
        {
            return await _gamesService
                .AddGameToGenreAsync(gameId, genreId, cancellationToken)
                .GetActionResultAsync();
        }


        [HttpDelete("{gameId:guid}/genres/{genreId:guid}")]
        public async Task<IActionResult> DeleteGameFromGenre(
            Guid gameId, Guid genreId, CancellationToken cancellationToken)
        {
            return await _gamesService
                .RemoveGameFromGenreAsync(gameId, genreId, cancellationToken)
                .GetActionResultAsync();
        }
    }
}