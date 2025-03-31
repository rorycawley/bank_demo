public interface ICartQueryService
{
    Task<CartReadModel> GetCartAsync(CartId cartId);
}
