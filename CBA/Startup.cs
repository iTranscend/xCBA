using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartupAttribute(typeof(CBA.Startup))]
namespace CBA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.Configure<PasswordHasherOptions>(options => options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3);

        //}
    }
}
