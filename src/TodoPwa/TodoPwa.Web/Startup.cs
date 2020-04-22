using AutoMapper;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using DotVVM.Framework.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using TodoPwa.BL.Installers;
using TodoPwa.Common.Installers;
using TodoPwa.DAL;
using TodoPwa.DAL.Installers;
using TodoPwa.Web.Installers;

namespace TodoPwa.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();
            services.AddDotVVM<DotvvmStartup>();

            var connectionString = configuration.GetConnectionString("db");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddAutoMapper(typeof(CommonInstaller), typeof(DALInstaller), typeof(BLInstaller), typeof(WebInstaller));

            new CommonInstaller().Install(services);
            new DALInstaller().Install(services);
            new BLInstaller().Install(services);
            new WebInstaller().Install(services);

            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsEnvironment("Development"))
            {
                app.UseHttpsRedirection();
            }

            // use DotVVM
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);
            dotvvmConfiguration.AssertConfigurationIsValid();

            // use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(env.WebRootPath)
            });
            UpdateDatabase(app);
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
