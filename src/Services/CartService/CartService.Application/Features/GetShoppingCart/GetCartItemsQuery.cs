
namespace CartService.Application.Features.GetCartItems;

public record GetCartItemsQuery(string UserName):IRequest<GetCartResponse>;
