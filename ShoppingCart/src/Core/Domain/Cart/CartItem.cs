public record CartItem(ProductId ProductId, Quantity Quantity)
{
    public CartItem AddQuantity(int quantity) => this with { Quantity = Quantity.Add(quantity) };
}