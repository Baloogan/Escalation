using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escalation.Startup))]
namespace Escalation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
