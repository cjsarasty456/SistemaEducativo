using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaEducativo.Startup))]
namespace SistemaEducativo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
