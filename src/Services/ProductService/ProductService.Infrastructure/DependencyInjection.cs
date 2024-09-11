using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Persistance;
using ProductService.Infrastructure.Repositories;


namespace ProductService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProductDb"));
            });

            services.AddScoped<ProductDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
