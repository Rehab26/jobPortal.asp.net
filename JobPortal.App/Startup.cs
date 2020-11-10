using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPortal.App.Startup))]
namespace JobPortal.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
