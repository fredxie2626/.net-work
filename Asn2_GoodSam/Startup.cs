using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asn2_GoodSam.Startup))]
namespace Asn2_GoodSam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
