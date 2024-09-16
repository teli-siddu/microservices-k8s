
using MediatR;
using ProductService.Shared.DTOs;

namespace ProductService.Application.Commands
{
    public record CreateProductCommand(ProductDto Product):IRequest<Guid>;

}