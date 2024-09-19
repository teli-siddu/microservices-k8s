
using MediatR;
using ProductService.Application.DTOs;

namespace ProductService.Application.Commands
{
    public record CreateProductCommand(ProductDto Product):IRequest<int>;

}