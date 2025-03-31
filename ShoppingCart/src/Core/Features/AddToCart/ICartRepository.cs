public interface ICartRepository
{
    Task<Cart?> LoadCartAsync(CartId cartId);
    Task SaveCartAsync(Cart cart);
}