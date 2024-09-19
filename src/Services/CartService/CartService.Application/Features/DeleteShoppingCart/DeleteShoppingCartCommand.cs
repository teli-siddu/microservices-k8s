

namespace CartService.Application.Features.DeleteShoppingCart;

public record DeleteShoppingCartCommand(string UserName) : IRequest<DeleteShoppingCartResponse>
{
}

