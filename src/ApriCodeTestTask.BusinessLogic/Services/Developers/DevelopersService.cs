using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.BusinessLogic.Shared.Validation;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;
using ApriCodeTestTask.Core.Entities;
using ApriCodeTestTask.Core.Models.Results;
using AutoMapper;

namespace ApriCodeTestTask.BusinessLogic.Services.Developers
{
    public class DevelopersService : IDevelopersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SharedValidator<DeveloperOperationRequest> _validator;

        public DevelopersService(IUnitOfWork unitOfWork, IMapper mapper,
            SharedValidator<DeveloperOperationRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ExecutionResult<DeveloperViewModel>>
            FindDeveloperAsync(Guid id,
                CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Developers.FindByIdAsync(id,
                cancellationToken);
            if (entity is null)
                return ExecutionResult<DeveloperViewModel>.NotFound();
            var viewModel = _mapper.Map<DeveloperViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<DeveloperViewModel>>
            CreateDeveloperAsync(DeveloperCreateRequest request,
                CancellationToken cancellationToken = default)
        {
            var validationResult = await
                _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new InvalidResult<DeveloperViewModel>(validationResult);
            var entity = _mapper.Map<Developer>(request);
            entity = await _unitOfWork.Developers.AddAsync(entity,
                cancellationToken);
            var viewModel = _mapper.Map<DeveloperViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<DeveloperViewModel>>
            UpdateDeveloperAsync(
                DeveloperUpdateRequest request,
                CancellationToken cancellationToken = default)
        {
            var validationResult = await
                _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new InvalidResult<DeveloperViewModel>(validationResult);
            var previous = await _unitOfWork.Developers.FindByIdAsync(
                request.Id, cancellationToken);
            if (previous is null)
                return ExecutionResult<DeveloperViewModel>.NotFound();
            var entity = _mapper.Map(request, previous);
            entity = await _unitOfWork.Developers.UpdateAsync(entity,
                cancellationToken);
            var viewModel = _mapper.Map<DeveloperViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<DevelopersListViewModel>>
            GetAllDevelopersAsync(CancellationToken cancellationToken = default)
        {
            var items =
                await _unitOfWork.Developers.GetAllAsync(cancellationToken);
            var viewModel = new DevelopersListViewModel(
                _mapper.Map<List<DeveloperViewModel>>(items));
            return new(viewModel);
        }

        public async Task<ExecutionResult<Nothing>> DeleteDeveloperAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Developers.FindByIdAsync(
                id, cancellationToken);
            if (entity is null)
                return ExecutionResult<Nothing>.NotFound();

            await _unitOfWork.Developers.RemoveAsync(entity, cancellationToken);
            return ExecutionResult<Nothing>.SuccessEmpty();
        }
    }
}