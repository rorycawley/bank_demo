using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Xunit;

public class WebApiTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;

    public WebApiTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task AddToCart_And_GetCart_EndToEnd()
    {
        var cartId = Guid.NewGuid();
        var addRequest = new
        {
            CartId = cartId,
            ProductId = "p123",
            Quantity = 2
        };

        // Add to cart
        var addResponse = await _client.PostAsJsonAsync("/cart/add", addRequest);
        addResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Get cart
        var getResponse = await _client.GetAsync($"/cart/{cartId}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var cart = await getResponse.Content.ReadFromJsonAsync<CartReadModel>();

        cart.Should().NotBeNull();
        cart.Items.Should().ContainSingle(i => i.ProductId == "p123" && i.Quantity == 2);
    }
}