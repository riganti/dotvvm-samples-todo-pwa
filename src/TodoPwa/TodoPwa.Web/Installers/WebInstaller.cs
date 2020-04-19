using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TodoPwa.Common.Installers;

namespace TodoPwa.Web.Installers
{
    public class WebInstaller : IInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}