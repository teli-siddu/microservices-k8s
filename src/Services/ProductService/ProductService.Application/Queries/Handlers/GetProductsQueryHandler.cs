using BuildingBlocks.Query;
using MediatR;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Queries.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductDto>>
    {
        private readonly ProductsService _productService;

        public GetProductsQueryHandler(ProductsService productService)
        {
            _productService = productService;
        }
        public async Task<PaginatedList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
           return await _productService.GetProductsAsync(request.QueryParameters);
        }
    }
}
