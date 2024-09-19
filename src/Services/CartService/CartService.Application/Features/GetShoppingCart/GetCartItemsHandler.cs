
namespace CartService.Application.Features.GetCartItems;
public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, GetCartResponse>
{
    public GetCartItemsHandler()
    {

    }
    public async Task<GetCartResponse> Handle(GetCartItemsQuery query, CancellationToken cancellationToken)
    {
        return new GetCartResponse();
    }
}

