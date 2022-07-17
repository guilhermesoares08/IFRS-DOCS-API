using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfrsDocs.Domain
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            //services.AddScoped<Ibase, RestaurantService>();

            //services.AddScoped<IDomainService, DomainService>();

            //services.AddScoped<IRestaurantAddressService, RestaurantAddressService>();

            //services.AddScoped<ISchedulingService, SchedulingService>();

            //services.AddScoped<IRestaurantExtensionService, RestaurantExtensionService>();

            return services;
        }
    }
}
