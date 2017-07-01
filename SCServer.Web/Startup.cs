using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCServer.Web.Startup))]
namespace SCServer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
