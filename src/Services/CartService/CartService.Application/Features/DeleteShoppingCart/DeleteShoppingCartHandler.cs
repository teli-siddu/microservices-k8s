namespace CartService.Application.Features.DeleteShoppingCart;
public class DeleteShoppingCartHandler : IRequestHandler<DeleteShoppingCartCommand, DeleteShoppingCartResponse>
{
    public async Task<DeleteShoppingCartResponse> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
    {
        return new DeleteShoppingCartResponse(true);
    }
}

