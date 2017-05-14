using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wohnungstausch24.Web.Mvc.Startup))]
namespace Wohnungstausch24.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
