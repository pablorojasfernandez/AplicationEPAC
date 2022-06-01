using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicationEPAC.Startup))]
namespace AplicationEPAC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
