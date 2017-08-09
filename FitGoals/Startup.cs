using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitGoals.Startup))]
namespace FitGoals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
