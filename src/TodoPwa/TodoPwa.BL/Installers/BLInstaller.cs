using Microsoft.Extensions.DependencyInjection;
using TodoPwa.BL.Facades;
using TodoPwa.Common;
using TodoPwa.Common.Installers;

namespace TodoPwa.BL.Installers
{
    public class BLInstaller : IInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromAssemblyOf<BLInstaller>()
                    .AddClasses(classes => classes.AssignableTo<IFacade>())
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        }
    }
}