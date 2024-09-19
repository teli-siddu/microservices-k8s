

namespace CartService.Application.Features.AddCartItem;

public class AddShoppingCartHandler : IRequestHandler<AddShoppingCartCommand, AddShoppingCartResponse>
{
    public async Task<AddShoppingCartResponse> Handle(AddShoppingCartCommand command, CancellationToken cancellationToken)
    {
        var cart = command.Cart;

        return new AddShoppingCartResponse("sid");
    }
}

