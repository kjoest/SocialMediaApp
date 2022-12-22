using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialMedia.WebMVC.Startup))]
namespace SocialMedia.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
