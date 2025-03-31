public class CartRepository : ICartRepository
{
    private readonly Dictionary<CartId, Cart> _carts = new();

    public Task<Cart?> LoadCartAsync(CartId cartId)
    {
        _carts.TryGetValue(cartId, out var cart);
        return Task.FromResult(cart);
    }

    public Task SaveCartAsync(Cart cart)
    {
        _carts[cart.Id] = cart;
        return Task.CompletedTask;
    }
}
