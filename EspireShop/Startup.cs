using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EspireShop.Startup))]
namespace EspireShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
