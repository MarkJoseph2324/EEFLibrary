using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EEFtoMVC.Startup))]
namespace EEFtoMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
