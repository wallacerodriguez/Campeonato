using Torneio.App.Interfaces;
using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.App
{
    public class TimeAppService : GenericAppService<Time>, ITimeAppService
    {
        private readonly ITimeService _timeService;
        public TimeAppService(ITimeService timeService)
            : base(timeService)
        {
            _timeService = timeService;
        }

    }
}
