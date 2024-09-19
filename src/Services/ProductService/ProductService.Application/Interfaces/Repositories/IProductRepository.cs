using BuildingBlocks.Query;
using ProductService.Application.DTOs;
using ProductService.Domain.Models;


namespace ProductService.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<int> CreateProductAsync(Product product);
        Task<Product> GetProductAsync(int id);

        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<PaginatedList<ProductDto>> GetPaginatedProductsAsync(int pageIndex, int pageSize);
    }
}
