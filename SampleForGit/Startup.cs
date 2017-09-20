using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleForGit.Startup))]
namespace SampleForGit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
