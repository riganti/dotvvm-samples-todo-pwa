using Microsoft.Extensions.DependencyInjection;
using Riganti.Utils.Infrastructure.Core;

namespace TodoPwa.Common.Installers
{
    public class CommonInstaller : IInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, UtcDateTimeProvider>();
        }
    }
}