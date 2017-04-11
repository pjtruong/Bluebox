using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bluebox.Startup))]
namespace Bluebox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
