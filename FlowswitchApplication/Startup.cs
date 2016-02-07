using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlowswitchApplication.Startup))]
namespace FlowswitchApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
