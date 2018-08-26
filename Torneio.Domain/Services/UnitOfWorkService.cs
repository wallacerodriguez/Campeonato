using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.Domain.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        private ITimeService timeService;
        private ICampeonatoService campeonatoService;
        private IPartidaService partidaService;
        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ITimeService TimeService
        {
            get { return timeService ?? (timeService = new TimeService(_unitOfWork.TimeRepository)); }
        }

        public ICampeonatoService CampeonatoService
        {
            get { return campeonatoService ?? (campeonatoService = new CampeonatoService(_unitOfWork.CampeonatoRepository)); }
        }

        public IPartidaService PartidaService
        {
            get { return partidaService ?? (partidaService = new PartidaService(_unitOfWork.PartidaRepository)); }
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }


        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
