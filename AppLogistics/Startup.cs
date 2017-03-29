using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppLogistics.Startup))]
namespace AppLogistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
