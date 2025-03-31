public record Cart(CartId Id, IReadOnlyList<CartItem> Items)
{
    public Cart AddItem(ProductId productId, Quantity quantity)
    {
        var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);

        List<CartItem> updatedItems;
        if (existingItem is null)
        {
            updatedItems = Items.Append(new CartItem(productId, quantity)).ToList();
        }
        else
        {
            updatedItems = Items.Select(i =>
                i.ProductId == productId ? i.AddQuantity(quantity.Value) : i).ToList();
        }

        return this with { Items = updatedItems };
    }
}