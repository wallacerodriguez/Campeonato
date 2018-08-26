using Torneio.Domain.Entities;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.Domain.Services
{
    public class PartidaService : GenericService<Partida>, IPartidaService
    {
        private readonly IPartidaRepository _partidaRepository;
        public PartidaService(IPartidaRepository partidaRepository) : base(partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }
    }
}
