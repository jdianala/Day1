using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityDay.Startup))]
namespace IdentityDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
