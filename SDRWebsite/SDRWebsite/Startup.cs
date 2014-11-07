using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SDRWebsite.Startup))]
namespace SDRWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
