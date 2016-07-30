using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NSPJ.Startup))]
namespace NSPJ
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
