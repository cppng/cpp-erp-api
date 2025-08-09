using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Extensions.Dependencies.Mediators.Event
{
    public static class EventHandlerServiceEnxtensions
    {
        public static IServiceCollection AddEventHandlerApplicationServices(this IServiceCollection services) 
        {
            services.AddMediator();

            return services;
        }
    }
}
