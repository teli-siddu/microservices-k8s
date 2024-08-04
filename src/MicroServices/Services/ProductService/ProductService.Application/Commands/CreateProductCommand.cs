
using MediatR;
using ProductService.Shared.DTOs;

namespace ProductService.Application.Commands
{
    public record CreateProductCommand(ProductDto ProductDto):IRequest<Guid>;

}