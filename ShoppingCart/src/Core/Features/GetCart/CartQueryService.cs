public class CartQueryService : ICartQueryService
{
    private readonly ICartRepository _cartRepository;

    public CartQueryService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartReadModel> GetCartAsync(CartId cartId)
    {
        var cart = await _cartRepository.LoadCartAsync(cartId);
        if (cart is null)
        {
            return new CartReadModel(cartId, new List<CartItemReadModel>());
        }

        var items = cart
            .Items.Select(i => new CartItemReadModel(i.ProductId.Value, i.Quantity.Value))
            .ToList();
        return new CartReadModel(cart.Id, items);
    }
}
