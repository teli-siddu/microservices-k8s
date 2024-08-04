
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Models;
using ProductService.Infrastructure.Persistance;
using ProductService.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
          return  await _dbContext.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToListAsync();
        }
    }
}
