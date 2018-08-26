using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Infra.Data.Context;

namespace Torneio.Infra.Data.Repositories
{
    public class PartidaRepository : GenericRepository<Partida>, IPartidaRepository
    {
        public PartidaRepository(BaseContext context) : base(context)
        {   
        }
    }
}
