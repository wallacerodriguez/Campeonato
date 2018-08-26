using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.Domain.Services
{
    public class CampeonatoService : GenericService<Campeonato>, ICampeonatoService
    {
 
        private readonly ICampeonatoRepository _campeonatoRepository;
        public CampeonatoService(ICampeonatoRepository campeonatoRepository)
            :base(campeonatoRepository)
        {
            _campeonatoRepository = campeonatoRepository;
        }
    }
}
