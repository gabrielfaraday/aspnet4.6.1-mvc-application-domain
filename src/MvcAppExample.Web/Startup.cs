using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAppExample.Web.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace MvcAppExample.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
