using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoonlightGarden.Startup))]
namespace MoonlightGarden
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
