using Microsoft.Owin;
using Owin;

[assembly: log4net.Config.XmlConfigurator(Watch =true)]
[assembly: OwinStartupAttribute(typeof(DFEitechLibrary.Startup))]
namespace DFEitechLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
