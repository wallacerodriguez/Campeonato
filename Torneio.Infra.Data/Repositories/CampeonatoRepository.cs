using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Infra.Data.Context;

namespace Torneio.Infra.Data.Repositories
{
    public class CampeonatoRepository : GenericRepository<Campeonato>, ICampeonatoRepository
    {
        public CampeonatoRepository(BaseContext context) : base(context)
        {
        }
    }
}
