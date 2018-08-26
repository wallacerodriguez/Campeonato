using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Torneio.MVC.App_Start;
using Torneio.MVC.AutoMapper;
using Unity;

namespace Torneio.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorInitializer.Initialize();
        }
    }
}
