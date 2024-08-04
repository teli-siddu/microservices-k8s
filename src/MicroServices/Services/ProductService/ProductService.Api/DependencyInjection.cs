using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Persistance;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            return services;
        }
    }
}
