using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Timesheets.Startup))]
namespace Timesheets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
