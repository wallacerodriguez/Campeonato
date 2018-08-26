using AutoMapper;
using Torneio.Domain.Entities;
using Torneio.MVC.ViewModel;

namespace Torneio.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Campeonato, CampeonatoViewModel>();
            CreateMap<Time,TimeViewModel>();
        }
    }
}