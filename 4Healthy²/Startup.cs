using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4Healthy_.Startup))]
namespace _4Healthy_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
