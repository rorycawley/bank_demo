public class GetCartHandler
{
    private readonly ICartQueryService _cartQueryService;

    public GetCartHandler(ICartQueryService cartQueryService)
    {
        _cartQueryService = cartQueryService;
    }

    public Task<CartReadModel> HandleAsync(GetCartQuery query)
    {
        return _cartQueryService.GetCartAsync(query.CartId);
    }
}
