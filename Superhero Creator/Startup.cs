using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Superhero_Creator.Startup))]
namespace Superhero_Creator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
