using Torneio.App.Interfaces;
using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.App
{
    public class CampeonatoAppService : GenericAppService<Campeonato>, ICampeonatoAppService
    {
        private readonly ICampeonatoService _campeonatoService;
        public CampeonatoAppService(ICampeonatoService campeonatoService)
            :base(campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }
    }
}
