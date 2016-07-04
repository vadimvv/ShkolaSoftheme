using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleASPmvc.Startup))]
namespace SimpleASPmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
