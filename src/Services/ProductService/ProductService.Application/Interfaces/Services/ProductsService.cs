using BuildingBlocks.Query;
using BuildingBlocks.Requests;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Interfaces.Services
{
    public class ProductsService
    {
        private readonly IProductRepository _productRepository;

        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginatedList<ProductDto>> GetProductsAsync(QueryParameters queryParams)
        {
            var products = await _productRepository.GetPaginatedProductsAsync(queryParams.PageNumber, queryParams.PageSize);
            return products;
        }
    }

}
