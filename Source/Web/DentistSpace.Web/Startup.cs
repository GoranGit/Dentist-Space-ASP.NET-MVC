using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DentistSpace.Web.Startup))]
namespace DentistSpace.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
