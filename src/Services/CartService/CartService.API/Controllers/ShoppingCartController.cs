using CartService.Application.Features.AddCartItem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ISender _sender;

        public ShoppingCartController(ISender sender)
        {
            _sender = sender;
        }
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        public async Task<IActionResult> Post(AddShoppingCartDto cart)
        {
           var response= await _sender.Send(new AddShoppingCartCommand(cart));

           return Created($"cart/{response.UserName}",response);
          
        }
    }
}
