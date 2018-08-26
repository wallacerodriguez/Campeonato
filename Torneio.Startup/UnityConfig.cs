using Torneio.App;
using Torneio.App.Interfaces;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;
using Torneio.Domain.Services;
using Torneio.Infra.Data.Context;
using Torneio.Infra.Data.Repositories;
using Unity;
using Unity.Lifetime;

namespace Torneio.Startup
{
    public class UnityConfig
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<BaseContext, BaseContext>();

            container.RegisterType<ITimeAppService, TimeAppService>();
            container.RegisterType<ICampeonatoAppService, CampeonatoAppService>();
            container.RegisterType<IUnitOfWorkAppService, UnitOfWorkAppService>();
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //typeof(IServiceBase<>)).To(typeof(ServiceBase<>)
            container.RegisterType<ITimeService, TimeService>();
            container.RegisterType<ICampeonatoService, CampeonatoService>();
            container.RegisterType<IUnitOfWorkService, UnitOfWorkService>();
            container.RegisterType(typeof(IGenericService<>), typeof(GenericService<>));

            container.RegisterType<ITimeRepository, TimeRepository>();
            container.RegisterType<ICampeonatoRepository, CampeonatoRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType(typeof(IGenericAppService<>), typeof(GenericAppService<>));


        }
    }
}
