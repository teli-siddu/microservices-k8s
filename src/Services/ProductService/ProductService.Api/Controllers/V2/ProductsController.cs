using Asp.Versioning;
using BuildingBlocks.Query;
using BuildingBlocks.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Commands;
using ProductService.Application.Queries;

namespace ProductService.Api.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> Get([AsParameters] QueryParameters QueryParameters)
        {
            var products = await _mediator.Send(new GetProductsQuery(QueryParameters));
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductCommand(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> Patch()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }

    }
}
