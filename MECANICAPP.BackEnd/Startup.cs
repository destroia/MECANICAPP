using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MECANICAPP.BackEnd.Startup))]
namespace MECANICAPP.BackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
