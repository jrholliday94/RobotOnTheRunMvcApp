using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RobotOnTheRun.Web.Startup))]
namespace RobotOnTheRun.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
