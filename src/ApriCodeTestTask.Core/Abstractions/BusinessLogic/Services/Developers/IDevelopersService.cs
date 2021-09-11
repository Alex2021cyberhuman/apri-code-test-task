using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models;
using ApriCodeTestTask.Core.Models.Results;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers
{
    public interface IDevelopersService
    {
        Task<ExecutionResult<DeveloperViewModel>> FindDeveloperAsync(Guid id,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<DeveloperViewModel>> CreateDeveloperAsync(
            DeveloperCreateRequest request,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<DeveloperViewModel>> UpdateDeveloperAsync(
            DeveloperUpdateRequest request,
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<DevelopersListViewModel>> GetAllDevelopersAsync(
            CancellationToken cancellationToken = default);

        Task<ExecutionResult<Nothing>> DeleteDeveloperAsync(
            Guid id, CancellationToken cancellationToken = default);
    }
}