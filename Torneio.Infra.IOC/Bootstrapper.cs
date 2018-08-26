using SimpleInjector;
using Torneio.App;
using Torneio.App.Interfaces;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;
using Torneio.Domain.Services;
using Torneio.Infra.Data.Context;
using Torneio.Infra.Data.Repositories;

namespace Torneio.Infra.IOC
{
    public class Bootstrapper
    {
      public static void RegisterServices(Container container)
        {


            container.Register(typeof(IGenericService<>), typeof(GenericService<>));

            container.Register(typeof(IGenericAppService<>), typeof(GenericAppService<>));

            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            container.Register<ITimeAppService, TimeAppService>();
            container.Register<IPartidaAppService, PartidaAppService>();
            container.Register<ICampeonatoAppService, CampeonatoAppService>();
            container.Register<IUnitOfWorkAppService, UnitOfWorkAppService>(Lifestyle.Scoped);

            container.Register<ITimeService, TimeService>();
            container.Register<IPartidaService, PartidaService>();
            container.Register<ICampeonatoService, CampeonatoService>();
            container.Register<IUnitOfWorkService, UnitOfWorkService>(Lifestyle.Scoped);

            container.Register<ITimeRepository, TimeRepository>();
            container.Register<IPartidaRepository, PartidaRepository>();
            container.Register<ICampeonatoRepository, CampeonatoRepository>();
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<BaseContext,BaseContext>(Lifestyle.Scoped);
   
        }
       
    }
}
