using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrandLabFixers.Startup))]
namespace GrandLabFixers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
