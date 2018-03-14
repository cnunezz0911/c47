using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(C47Example.Web.Startup))]
namespace C47Example.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
