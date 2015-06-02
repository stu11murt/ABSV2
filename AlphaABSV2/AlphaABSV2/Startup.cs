using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlphaABSV2.Startup))]
namespace AlphaABSV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
