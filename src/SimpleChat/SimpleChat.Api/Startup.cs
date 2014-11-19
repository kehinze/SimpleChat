using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SimpleChat.Api;

[assembly: OwinStartup(typeof(Startup))]
namespace SimpleChat.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}