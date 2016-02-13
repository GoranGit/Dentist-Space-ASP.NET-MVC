namespace DentistSpace.Web
{
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using DentistSpace.Web.Infrastructure.Mapping;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
