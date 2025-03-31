using FluentAssertions; // Shouldly
using Xunit;

public class CartTests
{
    [Fact]
    public void AddItem_Should_Add_New_Item_When_Product_Not_Exists()
    {
        // Arrange
        var cart = new Cart(new CartId(Guid.NewGuid()), new List<CartItem>());
        var productId = new ProductId("p123");
        var quantity = new Quantity(2);

        // Act
        var updatedCart = cart.AddItem(productId, quantity);

        // Assert
        updatedCart
            .Items.Should()
            .ContainSingle()
            .Which.Should()
            .BeEquivalentTo(new CartItem(productId, quantity));
    }

    [Fact]
    public void AddItem_Should_Increment_Quantity_When_Product_Exists()
    {
        // Arrange
        var productId = new ProductId("p123");
        var initialQuantity = new Quantity(1);
        var cart = new Cart(
            new CartId(Guid.NewGuid()),
            new List<CartItem> { new(productId, initialQuantity) }
        );

        var addedQuantity = new Quantity(2);

        // Act
        var updatedCart = cart.AddItem(productId, addedQuantity);

        // Assert
        updatedCart
            .Items.Should()
            .ContainSingle()
            .Which.Quantity.Should()
            .BeEquivalentTo(new Quantity(3));
    }
}
