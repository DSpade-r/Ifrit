using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ifrit.Startup))]
namespace Ifrit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
