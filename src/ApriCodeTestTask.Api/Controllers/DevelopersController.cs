using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Api.Extensions;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models;
using Microsoft.AspNetCore.Mvc;

namespace ApriCodeTestTask.Api.Controllers
{
    [ApiController]
    [Route("api/developers")]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopersService _developersService;

        public DevelopersController(IDevelopersService developersService)
        {
            _developersService = developersService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDeveloper(Guid id,
            CancellationToken cancellationToken)
        {
            return await _developersService
                .FindDeveloperAsync(id, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetDevelopers(
            CancellationToken cancellationToken)
        {
            return await _developersService
                .GetAllDevelopersAsync(cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostDeveloper(
            DeveloperCreateRequest request, CancellationToken cancellationToken)
        {
            return await _developersService
                .CreateDeveloperAsync(request, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutDeveloper(Guid id,
            DeveloperUpdateRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            return await _developersService
                .UpdateDeveloperAsync(request, cancellationToken)
                .GetActionResultAsync();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDeveloper(Guid id,
            CancellationToken cancellationToken)
        {
            return await _developersService
                .DeleteDeveloperAsync(id, cancellationToken)
                .GetActionResultAsync();
        }
    }
}