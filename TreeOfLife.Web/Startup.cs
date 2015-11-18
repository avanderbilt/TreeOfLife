using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeOfLife.Web.Startup))]
namespace TreeOfLife.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
