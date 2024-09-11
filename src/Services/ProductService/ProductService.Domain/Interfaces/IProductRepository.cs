using ProductService.Domain.Models;
using ProductService.Shared.DTOs;

namespace ProductService.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Guid> CreateProductAsync(Product product);
        Task<Product> GetProductAsync(Guid id);

        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
