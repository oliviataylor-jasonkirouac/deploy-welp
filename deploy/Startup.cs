using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(deploy.Startup))]
namespace deploy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
