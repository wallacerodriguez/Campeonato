using System;
using Torneio.Domain.Entities;

namespace Torneio.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITimeRepository TimeRepository { get; }
        ICampeonatoRepository CampeonatoRepository { get; }
        IPartidaRepository PartidaRepository { get; }

        void Commit();
    }
}
