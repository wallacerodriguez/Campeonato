using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Infra.Data.Context;

namespace Torneio.Infra.Data.Repositories
{
    public class TimeRepository : GenericRepository<Time>, ITimeRepository
    {
        public TimeRepository(BaseContext context) : base(context)
        {
        }
    }
}
