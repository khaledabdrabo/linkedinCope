using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.MVC.LinkedIn.Startup))]
namespace ITI.MVC.LinkedIn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
