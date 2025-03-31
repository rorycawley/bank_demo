using SimpleInjector;
using SimpleInjector.Lifestyles;
using Microsoft.EntityFrameworkCore;
using Core.Infrastructure;
using Xunit;

public class CartRepositoryIntegrationTests
{
    private readonly Container _container;

    public CartRepositoryIntegrationTests()
    {
        _container = new Container();
        _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        var options = new DbContextOptionsBuilder<ShoppingCartDbContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;

        var context = new ShoppingCartDbContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();

        _container.RegisterInstance(context);
        _container.Register<ICartRepository, CartRepository>(Lifestyle.Scoped);

        _container.Verify();
    }

    [Fact]
    public async Task CartRepository_Should_Save_And_Load_Cart_Correctly()
    {
        // Explicitly create async scope
        await using (AsyncScopedLifestyle.BeginScope(_container))
        {
            var repo = _container.GetInstance<ICartRepository>();

            var cartId = new CartId(Guid.NewGuid());
            var cart = new Cart(cartId, new List<CartItem>());

            await repo.SaveCartAsync(cart);
            var loadedCart = await repo.LoadCartAsync(cartId);

            Assert.NotNull(loadedCart);
            Assert.Equal(cartId, loadedCart.Id);
        }
    }
}
