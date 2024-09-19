using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Infrastructure.Persistance;
using ProductService.Infrastructure.Repositories;


namespace ProductService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EShopDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProductDb"));
            });

            services.AddScoped<EShopDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IRepository<>),typeof(EfRepository<>));
            return services;
        }
    }
}
