using FastEndpoints;

namespace WebApi.Endpoints;

public class GetCartEndpoint : EndpointWithoutRequest<CartReadModel>
{
    private readonly GetCartHandler _handler;
    
    public GetCartEndpoint(GetCartHandler handler)
    {
        _handler = handler;
    }
    
    public override void Configure()
    {
        Get("/cart/{cartId}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var cartIdGuid = Route<Guid>("cartId");
        
        // Create a CartId value object
        var cartId = new CartId(cartIdGuid);
        
        // Create the query with the CartId value object
        var query = new GetCartQuery(cartId);
        
        var cart = await _handler.HandleAsync(query);
        
        if (cart == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(cart, cancellation: ct);
    }
}