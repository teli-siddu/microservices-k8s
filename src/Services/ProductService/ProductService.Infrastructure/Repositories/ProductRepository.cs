
using AutoMapper;
using BuildingBlocks.Query;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Models;
using ProductService.Infrastructure.Extensions;
using ProductService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository :EfRepository<Product>, IProductRepository
    {
        private readonly EShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(EShopDbContext dbContext, IMapper mapper):base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> CreateProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<PaginatedList<ProductDto>> GetPaginatedProductsAsync(int pageIndex, int pageSize)
        {
            var query = _dbSet.AsQueryable();
            var productDtos = _mapper.ProjectTo<ProductDto>(query);
            var response= await productDtos.PaginateAsync(pageIndex, pageSize);
            return response;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
          return  await _dbContext.Products.Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price
            }).ToListAsync();

        }
    }
}
