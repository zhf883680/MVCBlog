using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBlogByMVC.Startup))]
namespace MyBlogByMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
