using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCaching.Startup))]
namespace MvcCaching
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
