using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;

[assembly: OwinStartupAttribute(typeof(Escalation.Startup))]
namespace Escalation
{
    public partial class Startup
    {
        public static DateTime compilationDateTime = getCreationDate();
        public static string version = "Escalation Alpha 1";
        private static DateTime getCreationDate()
        {
            return System.IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
        }
        public void Configuration(IAppBuilder app)
        {

            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            ConfigureAuth(app);
            app.MapSignalR(hubConfiguration);
        }
    }
}
