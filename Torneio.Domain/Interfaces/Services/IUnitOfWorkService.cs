using System;
using Torneio.Domain.Entities;

namespace Torneio.Domain.Interfaces.Services
{
    public interface IUnitOfWorkService : IDisposable
    {
        ITimeService TimeService { get; }
        ICampeonatoService CampeonatoService { get; }
        IPartidaService PartidaService { get; }

        void Commit();
    }
}
