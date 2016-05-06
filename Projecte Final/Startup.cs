using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projecte_Final.Startup))]
namespace Projecte_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
