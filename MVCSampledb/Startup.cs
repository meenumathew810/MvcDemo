using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSampledb.Startup))]
namespace MVCSampledb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
