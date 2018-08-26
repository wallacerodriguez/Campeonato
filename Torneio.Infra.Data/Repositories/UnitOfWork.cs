using System;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Infra.Data.Context;

namespace Torneio.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BaseContext context = null;
        private ITimeRepository timeRepository;
        private ICampeonatoRepository campeonatoRepository;
        private IPartidaRepository partidaRepository;

        public UnitOfWork()
        {
            context = new BaseContext();
        }

        public ITimeRepository TimeRepository
        {
            get { return timeRepository ?? (timeRepository = new TimeRepository(context)); }
        }

        public ICampeonatoRepository CampeonatoRepository
        {
            get { return campeonatoRepository ?? (campeonatoRepository = new CampeonatoRepository(context)); }
        }

        public IPartidaRepository PartidaRepository
        {
            get { return partidaRepository ?? (partidaRepository = new PartidaRepository(context)); }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
