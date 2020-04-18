using Microsoft.Extensions.DependencyInjection;

namespace TodoPwa.Common.Installers
{
    public interface IInstaller
    {
        void Install(IServiceCollection services);
    }
}