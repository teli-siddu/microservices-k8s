using BuildingBlocks.Query;
using BuildingBlocks.Requests;
using MediatR;
using ProductService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Queries
{
    public record GetProductsQuery(QueryParameters QueryParameters) :IRequest<PaginatedList<ProductDto>>;
}
