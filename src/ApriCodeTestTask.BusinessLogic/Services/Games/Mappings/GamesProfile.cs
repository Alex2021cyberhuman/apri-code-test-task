using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Entities;
using AutoMapper;

namespace ApriCodeTestTask.BusinessLogic.Services.Games.Mappings
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<GameCreateRequest, Game>();
            CreateMap<GameUpdateRequest, Game>();
            CreateMap<Game, GameViewModel>();
            CreateMap<Developer, GameViewModelDeveloperDto>();
            CreateMap<Genre, GameViewModelGenreDto>();
        }
    }
}