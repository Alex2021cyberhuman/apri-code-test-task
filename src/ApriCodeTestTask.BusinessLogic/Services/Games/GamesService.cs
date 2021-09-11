using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.BusinessLogic.Shared.Validation;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;
using ApriCodeTestTask.Core.Entities;
using ApriCodeTestTask.Core.Models.Results;
using AutoMapper;

namespace ApriCodeTestTask.BusinessLogic.Services.Games
{
    public class GamesService : IGamesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SharedValidator<GameOperationRequest> _validator;

        public GamesService(IUnitOfWork unitOfWork, IMapper mapper,
            SharedValidator<GameOperationRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ExecutionResult<GameViewModel>>
            FindGameAsync(Guid id,
                CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Games.FindByIdAsync(id,
                cancellationToken);
            if (entity is null)
                return ExecutionResult<GameViewModel>.NotFound();
            var viewModel = _mapper.Map<GameViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GameViewModel>>
            CreateGameAsync(GameCreateRequest request,
                CancellationToken cancellationToken = default)
        {
            var validationResult = await
                _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new InvalidResult<GameViewModel>(validationResult);
            var entity = _mapper.Map<Game>(request);
            entity = await _unitOfWork.Games.AddAsync(entity,
                cancellationToken);
            var viewModel = _mapper.Map<GameViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GameViewModel>>
            UpdateGameAsync(
                GameUpdateRequest request,
                CancellationToken cancellationToken = default)
        {
            var validationResult = await
                _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return new InvalidResult<GameViewModel>(validationResult);
            var previous = await _unitOfWork.Games.FindByIdAsync(
                request.Id, cancellationToken);
            if (previous is null)
                return ExecutionResult<GameViewModel>.NotFound();
            var entity = _mapper.Map(request, previous);
            entity = await _unitOfWork.Games.UpdateAsync(entity,
                cancellationToken);
            var viewModel = _mapper.Map<GameViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GamesListViewModel>>
            GetAllGamesAsync(CancellationToken cancellationToken = default)
        {
            var items =
                await _unitOfWork.Games.GetAllAsync(cancellationToken);
            var viewModel = new GamesListViewModel(
                _mapper.Map<List<GameViewModel>>(items));
            return new(viewModel);
        }

        public async Task<ExecutionResult<GamesListViewModel>>
            GetAllGamesOfGenreAsync(Guid genreId,
                CancellationToken cancellationToken = default)
        {
            var items =
                await _unitOfWork.Games.GetByGenreIdAsync(genreId,
                    cancellationToken);
            var viewModel = new GamesListViewModel(
                _mapper.Map<List<GameViewModel>>(items));
            return new(viewModel);
        }

        public async Task<ExecutionResult<GameViewModel>> AddGameToGenreAsync(
            Guid gameId, Guid genreId,
            CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Games.FindByIdAsync(
                gameId, cancellationToken);
            if (entity is null)
                return ExecutionResult<GameViewModel>.NotFound();
            if (entity.Genres.Any(g => g.Id == genreId))
                return ExecutionResult<GameViewModel>.BadRequest();
            var genre = await _unitOfWork.Genres.FindByIdAsync(
                genreId, cancellationToken);
            if (genre is null)
                return ExecutionResult<GameViewModel>.NotFound();
            
            await _unitOfWork.Games.UpdateAsync(entity, cancellationToken);
            var viewModel = _mapper.Map<GameViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<GameViewModel>>
            RemoveGameFromGenreAsync(Guid gameId, Guid genreId,
                CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Games.FindByIdAsync(
                gameId, cancellationToken);
            if (entity is null)
                return ExecutionResult<GameViewModel>.NotFound();
            var genre = entity.Genres.FirstOrDefault(g => g.Id == genreId);
            if (genre is null)
                return ExecutionResult<GameViewModel>.BadRequest();
            entity.Genres.Remove(genre);
            await _unitOfWork.Games.UpdateAsync(entity, cancellationToken);
            var viewModel = _mapper.Map<GameViewModel>(entity);
            return new(viewModel);
        }

        public async Task<ExecutionResult<Nothing>> DeleteGameAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Games.FindByIdAsync(
                id, cancellationToken);
            if (entity is null)
                return ExecutionResult<Nothing>.NotFound();

            await _unitOfWork.Games.RemoveAsync(entity, cancellationToken);
            return ExecutionResult<Nothing>.SuccessEmpty();
        }
    }
}