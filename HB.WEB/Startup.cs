using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HB.WEB.Startup))]
namespace HB.WEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
