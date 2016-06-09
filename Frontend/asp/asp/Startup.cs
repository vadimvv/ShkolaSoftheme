using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.Startup))]
namespace asp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
