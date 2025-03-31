using FastEndpoints;

namespace WebApi.Endpoints;

// Define a request class that matches what your test expects
public class AddToCartRequest
{
    public Guid CartId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public class AddToCartEndpoint : Endpoint<AddToCartRequest>
{
    private readonly AddToCartHandler _handler;
    
    public AddToCartEndpoint(AddToCartHandler handler)
    {
        _handler = handler;
    }
    
    public override void Configure()
    {
        Post("/cart/add");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(AddToCartRequest req, CancellationToken ct)
    {
        // Create value objects for the command
        var cartId = new CartId(req.CartId);
        var productId = new ProductId(req.ProductId);
        var quantity = new Quantity(req.Quantity);
        
        // Create the command with value objects
        var command = new AddToCartCommand(cartId, productId, quantity);
        
        await _handler.HandleAsync(command);
        await SendOkAsync(ct);
    }
}