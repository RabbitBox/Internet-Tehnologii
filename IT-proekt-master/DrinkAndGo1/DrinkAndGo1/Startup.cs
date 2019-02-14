using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrinkAndGo1.Startup))]
namespace DrinkAndGo1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
