using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(typeof(ProductMappingProfile));
            return services;
        }
    }
}
