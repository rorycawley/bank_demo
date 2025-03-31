using SimpleInjector;

var container = new Container();

container.Register<ICartRepository, CartRepository>(Lifestyle.Transient);
container.Register<ICartQueryService, CartQueryService>(Lifestyle.Transient);
container.Register<AddToCartHandler>(Lifestyle.Transient);
container.Register<GetCartHandler>(Lifestyle.Transient);

container.Verify();

// Example usage
// Example usage:
if (args.Length >= 4 && args[0] == "add")
{
    var handler = container.GetInstance<AddToCartHandler>();
    var command = new AddToCartCommand(
        new CartId(Guid.Parse(args[1])),
        new ProductId(args[2]),
        new Quantity(int.Parse(args[3]))
    );

    await handler.HandleAsync(command); // <-- Correct async invocation
    Console.WriteLine("Product added successfully");
}
