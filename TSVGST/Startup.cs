using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSVGST.Startup))]
namespace TSVGST
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
