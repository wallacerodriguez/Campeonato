using Torneio.App.Interfaces;
using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.App
{
    public class PartidaAppService : GenericAppService<Partida>, IPartidaAppService
    {
        private readonly IPartidaService _partidaService;
        public PartidaAppService(IPartidaService partidaService) : base(partidaService)
        {
            _partidaService = partidaService;
        }
    }
}
