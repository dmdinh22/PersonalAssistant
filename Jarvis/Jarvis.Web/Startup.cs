using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jarvis.Web.Startup))]
namespace Jarvis.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
