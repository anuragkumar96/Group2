using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Group2.Startup))]
namespace Group2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
