public record CartReadModel(CartId CartId, IReadOnlyList<CartItemReadModel> Items);

public record CartItemReadModel(string ProductId, int Quantity);
