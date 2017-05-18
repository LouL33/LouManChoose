using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LouManChoose.Startup))]
namespace LouManChoose
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
