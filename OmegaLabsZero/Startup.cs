using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OmegaLabsZero.Startup))]
namespace OmegaLabsZero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
