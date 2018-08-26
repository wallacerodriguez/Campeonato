using System;

namespace Torneio.App.Interfaces
{
    public interface IUnitOfWorkAppService : IDisposable
    {
        ITimeAppService TimeAppService { get; }
        ICampeonatoAppService CampeonatoAppService { get; }
        IPartidaAppService PartidaAppService { get; }

        void Commit();
    }
}
