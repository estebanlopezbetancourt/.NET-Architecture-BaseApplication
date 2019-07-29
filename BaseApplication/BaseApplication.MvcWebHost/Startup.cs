using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseApplication.MvcWebHost.Startup))]
namespace BaseApplication.MvcWebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
