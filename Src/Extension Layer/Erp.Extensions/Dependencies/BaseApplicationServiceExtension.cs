using Erp.Extensions.Dependencies.ApplicationCore;
using Erp.Extensions.Dependencies.Domain;
using Erp.Extensions.Dependencies.Infrastructure;
using Erp.Extensions.Dependencies.Mediators.Event;
using Erp.Extensions.Dependencies.Mediators.Handlers;
using Erp.Extensions.Dependencies.Mediators.QueryHandlers;
using Erp.Helper.Configuration;
using Helper_Layer.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Extensions.Dependencies
{
    public static class BaseApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {

            services.AddAutoMapper(typeof(MappingProfiles));

            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();

            services.AddApplicationCoreServices();
            services.AddCommandHandlerApplicationServics();
            services.AddEventHandlerApplicationServices();
            services.AddQueryHandlerApplicationServics();
            services.AddInfrastureServices();
            services.AddDomainServices();

            services.Configure<AppSettings>(appSettings.GetSection(nameof(AppSettings)));

            return services;
        }
    }
}
