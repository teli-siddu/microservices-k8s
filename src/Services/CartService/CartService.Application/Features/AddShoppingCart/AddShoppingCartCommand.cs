

namespace CartService.Application.Features.AddCartItem;

    public record AddShoppingCartCommand(AddShoppingCartDto Cart):IRequest<AddShoppingCartResponse>;
    

