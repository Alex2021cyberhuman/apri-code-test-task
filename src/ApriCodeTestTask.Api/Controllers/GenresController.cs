using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Api.Extensions;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApriCodeTestTask.Api.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genreService;

        public GenresController(IGenresService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetGenre(Guid id,
            CancellationToken cancellationToken)
        {
            return await _genreService.FindGenreAsync(id, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres(
            CancellationToken cancellationToken)
        {
            return await _genreService.GetAllGenresAsync(cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostGenre(
            GenreCreateRequest request, CancellationToken cancellationToken)
        {
            return await _genreService
                .CreateGenreAsync(request, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutGenre(Guid id,
            GenreUpdateRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            return await _genreService
                .UpdateGenreAsync(request, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGenre(Guid id,
            CancellationToken cancellationToken)
        {
            return await _genreService.DeleteGenreAsync(id, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpGet("{genreId:guid}/games")]
        public async Task<IActionResult> GetGamesOfGenre(Guid genreId,
            [FromServices] IGamesService gamesService,
            CancellationToken cancellationToken)
        {
            return await gamesService
                .GetAllGamesOfGenreAsync(genreId, cancellationToken)
                .GetActionResultAsync();
        }
    }
}