using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models;
using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.Models;
using ApriCodeTestTask.Core.Entities;
using AutoMapper;

namespace ApriCodeTestTask.BusinessLogic.Services.Genres.Mappings
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<GenreCreateRequest, Genre>();
            CreateMap<GenreUpdateRequest, Genre>();
            CreateMap<Genre, GenreViewModel>();
        }
    }
}