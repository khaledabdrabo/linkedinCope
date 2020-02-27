using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.MVC.LinkedIn.Web.Startup))]
namespace ITI.MVC.LinkedIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
