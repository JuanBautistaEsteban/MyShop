using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShop.Web.Startup))]
namespace MyShop.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
