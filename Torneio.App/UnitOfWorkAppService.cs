using Torneio.App.Interfaces;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.App
{
    public class UnitOfWorkAppService : IUnitOfWorkAppService
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private  ITimeAppService timeAppService;
        private  ICampeonatoAppService campeonatoAppService;
        private IPartidaAppService partidaAppService;

        public UnitOfWorkAppService(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }


        public ITimeAppService TimeAppService
        {
            get { return timeAppService ?? (timeAppService = new TimeAppService(_unitOfWorkService.TimeService)); }
        }

        public ICampeonatoAppService CampeonatoAppService
        {
            get { return campeonatoAppService ?? (campeonatoAppService = new CampeonatoAppService(_unitOfWorkService.CampeonatoService)); }
        }

        public IPartidaAppService PartidaAppService
        {
            get { return partidaAppService ?? (partidaAppService = new PartidaAppService(_unitOfWorkService.PartidaService)); }
        }

        public void Commit()
        {
            _unitOfWorkService.Commit();
        }

        public void Dispose()
        {
            _unitOfWorkService.Dispose();
        }
    }
}
