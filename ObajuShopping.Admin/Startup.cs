using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ObajuShopping.Admin.Startup))]
namespace ObajuShopping.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
