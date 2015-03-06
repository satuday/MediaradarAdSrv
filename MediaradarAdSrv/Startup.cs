using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaradarAdSrv.Startup))]
namespace MediaradarAdSrv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
