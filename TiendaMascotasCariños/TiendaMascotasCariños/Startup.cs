using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaMascotasCariños.Startup))]
namespace TiendaMascotasCariños
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
