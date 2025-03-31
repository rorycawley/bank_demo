public class AddToCartHandler
{
    private readonly ICartRepository _cartRepository;

    public AddToCartHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task HandleAsync(AddToCartCommand command)
    {
        var cart = await _cartRepository.LoadCartAsync(command.CartId)
                   ?? new Cart(command.CartId, new List<CartItem>());

        var updatedCart = cart.AddItem(command.ProductId, command.Quantity);

        await _cartRepository.SaveCartAsync(updatedCart);
    }
}