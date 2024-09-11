using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Persistance;
using ProductService.Infrastructure.Seeding;

namespace ProductService.Api.Extensions
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await DatabaseSeeder.SeedAsync(context);
        }
    }
}
