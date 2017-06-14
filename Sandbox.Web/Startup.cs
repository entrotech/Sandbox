using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sandbox.Web.Startup))]
namespace Sandbox.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
