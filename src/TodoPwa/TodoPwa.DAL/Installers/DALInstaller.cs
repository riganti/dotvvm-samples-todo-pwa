using Microsoft.Extensions.DependencyInjection;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using TodoPwa.Common.Installers;
using TodoPwa.DAL.Repositories;

namespace TodoPwa.DAL.Installers
{
    public class DALInstaller : IInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWorkProvider, EntityFrameworkUnitOfWorkProvider<AppDbContext>>();
            services.AddSingleton<IUnitOfWorkRegistry>(new AsyncLocalUnitOfWorkRegistry());

            services.Scan(scan =>
                scan.FromAssemblyOf<DALInstaller>()
                    .AddClasses(classes => classes.AssignableTo(typeof(RepositoryBase<,>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        }
    }
}