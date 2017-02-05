using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudioLab.Startup))]
namespace StudioLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
