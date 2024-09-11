using MediatR;
using ProductService.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Queries
{
    public record GetProductsQuery:IRequest<IEnumerable<ProductDto>>;
}
