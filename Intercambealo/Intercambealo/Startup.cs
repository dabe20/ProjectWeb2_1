using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intercambealo.Startup))]
namespace Intercambealo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
