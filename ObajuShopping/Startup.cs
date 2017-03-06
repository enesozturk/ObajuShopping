using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ObajuShopping.Startup))]
namespace ObajuShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
