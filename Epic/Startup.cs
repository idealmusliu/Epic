using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epic.Startup))]
namespace Epic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
