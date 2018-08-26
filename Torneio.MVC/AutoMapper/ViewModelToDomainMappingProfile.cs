using AutoMapper;
using Torneio.Domain.Entities;
using Torneio.MVC.ViewModel;

namespace Torneio.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CampeonatoViewModel, Campeonato>();
            CreateMap<TimeViewModel, Time>();
        }
    }
}