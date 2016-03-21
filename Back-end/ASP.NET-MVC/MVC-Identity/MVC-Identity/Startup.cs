using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Identity.Startup))]
namespace MVC_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
