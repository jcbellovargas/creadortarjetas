using log4net.Config;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LPPA.WebSite.Startup))]
namespace LPPA.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            XmlConfigurator.Configure();
        }
    }
}
