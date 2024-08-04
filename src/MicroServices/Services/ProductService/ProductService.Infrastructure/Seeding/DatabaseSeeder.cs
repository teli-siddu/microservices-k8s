using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Extensions;
using ProductService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Seeding
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(ProductDbContext context)
        {
            if (!await context.Products.AnyAsync())
            {
                await context.Products.AddRangeAsync(InitialData.Products);
                await context.SaveChangesAsync();
            }
        }

       
    }
}
