using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.Domain.Services
{
    public class TimeService : GenericService<Time>, ITimeService
    {
        private readonly ITimeRepository _timeRepository;
        public TimeService(ITimeRepository timeRepository)
            : base(timeRepository)
        {
            _timeRepository = timeRepository;


        }
    }
}
