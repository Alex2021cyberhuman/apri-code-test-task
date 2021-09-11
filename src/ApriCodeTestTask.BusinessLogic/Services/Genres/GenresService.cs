using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.BusinessLogic.Shared.Validation;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.Models;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;
using ApriCodeTestTask.Core.Entities;
using ApriCodeTestTask.Core.Models.Results;
using AutoMapper;

namespace ApriCodeTestTask.BusinessLogic.Services.Genres
{
    public class GenresService : IGenresService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SharedValidator<GenreOperationRequest> _validator;

        public GenresService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            SharedValidator<GenreOperationRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ExecutionResult<GenreViewModel>>
            FindGenreAsync(Guid id,
                CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Genres.FindByIdAsync(id,
                cancellationToken);
            if (entity is null)
                return ExecutionResult<GenreViewModel>.NotFound();
            var viewModel = _mapper.Map<GenreViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GenreViewModel>>
            CreateGenreAsync(GenreCreateRequest request,
                CancellationToken cancellationToken = default)
        {
            var validationResult = await
                _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new InvalidResult<GenreViewModel>(validationResult);
            var entity = _mapper.Map<Genre>(request);
            entity = await _unitOfWork.Genres.AddAsync(entity,
                cancellationToken);
            var viewModel = _mapper.Map<GenreViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GenreViewModel>>
            UpdateGenreAsync(
                GenreUpdateRequest request,
                CancellationToken cancellationToken = default)
        {
            var validationResult = await
                _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new InvalidResult<GenreViewModel>(validationResult);
            var previous = await _unitOfWork.Genres.FindByIdAsync(
                request.Id, cancellationToken);
            if (previous is null)
                return ExecutionResult<GenreViewModel>.NotFound();
            var entity = _mapper.Map(request, previous);
            entity = await _unitOfWork.Genres.UpdateAsync(entity,
                cancellationToken);
            var viewModel = _mapper.Map<GenreViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GenresListViewModel>>
            GetAllGenresAsync(CancellationToken cancellationToken = default)
        {
            var items =
                await _unitOfWork.Genres.GetAllAsync(cancellationToken);
            var viewModel = new GenresListViewModel(
                _mapper.Map<List<GenreViewModel>>(items));
            return new(viewModel);
        }

        public async Task<ExecutionResult<Nothing>> DeleteGenreAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Genres.FindByIdAsync(
                id, cancellationToken);
            if (entity is null)
                return ExecutionResult<Nothing>.NotFound();

            await _unitOfWork.Genres.RemoveAsync(entity, cancellationToken);
            return ExecutionResult<Nothing>.SuccessEmpty();
        }
    }
}