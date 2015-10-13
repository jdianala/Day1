using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Resume.Startup))]
namespace Online_Resume
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
