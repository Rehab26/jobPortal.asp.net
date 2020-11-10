using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JobPortal.UI.StartupOwin))]

namespace JobPortal.UI
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
