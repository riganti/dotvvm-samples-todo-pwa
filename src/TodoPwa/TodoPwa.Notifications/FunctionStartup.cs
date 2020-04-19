﻿using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;
using TodoPwa.BL.Installers;
using TodoPwa.Common.Installers;
using TodoPwa.DAL;
using TodoPwa.DAL.Installers;
using TodoPwa.Notifications;

[assembly: WebJobsStartup(typeof(FunctionStartup))]
namespace TodoPwa.Notifications
{
    public class FunctionStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            new CommonInstaller().Install(builder.Services);
            new DALInstaller().Install(builder.Services);
            new BLInstaller().Install(builder.Services);

            builder.Services.AddAutoMapper(typeof(CommonInstaller), typeof(DALInstaller), typeof(BLInstaller), typeof(FunctionsStartup));

            AddAppSettingsToConfiguration(builder.Services, out var configuration);
            var connectionString = configuration.GetConnectionString("db");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
        }

        private void AddAppSettingsToConfiguration(IServiceCollection services, out IConfiguration configuration)
        {
            string currentDirectory;
            currentDirectory = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID"))
                ? Environment.CurrentDirectory
                : "/home/site/wwwroot";

            var configurationBuilder = new ConfigurationBuilder();

            var serviceDescriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IConfiguration));
            if (serviceDescriptor?.ImplementationInstance is IConfiguration configRoot)
            {
                configurationBuilder.AddConfiguration(configRoot);
            }

            configuration = configurationBuilder.SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), configuration));
        }
    }
}