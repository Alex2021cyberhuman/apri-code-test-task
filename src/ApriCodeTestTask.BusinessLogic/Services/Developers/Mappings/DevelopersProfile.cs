using ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models;
using ApriCodeTestTask.Core.Entities;
using AutoMapper;

namespace ApriCodeTestTask.BusinessLogic.Services.Developers.Mappings
{
    public class DevelopersProfile : Profile
    {
        public DevelopersProfile()
        {
            CreateMap<DeveloperCreateRequest, Developer>();
            CreateMap<DeveloperUpdateRequest, Developer>();
            CreateMap<Developer, DeveloperViewModel>();
        }
    }
}