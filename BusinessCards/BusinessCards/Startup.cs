using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessCards.Startup))]
namespace BusinessCards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
