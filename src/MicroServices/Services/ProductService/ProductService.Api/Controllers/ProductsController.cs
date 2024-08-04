using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Commands;
using ProductService.Application.Queries;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products= await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductCommand(CreateProductCommand command)
        {
          var result=  await _mediator.Send(command);
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
