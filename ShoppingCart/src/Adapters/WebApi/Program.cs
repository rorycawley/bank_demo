using FastEndpoints;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Lifestyles;

// Make Program a non-static class that can be used by WebApplicationFactory
public partial class Program 
{
    // Main entry point - keep it simple to avoid initialization issues
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add FastEndpoints
        builder.Services.AddFastEndpoints();
        
        // Set up Simple Injector
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        
        // Register services
        container.Register<ICartRepository, CartRepository>(Lifestyle.Scoped);
        container.Register<ICartQueryService, CartQueryService>(Lifestyle.Scoped);
        container.Register<AddToCartHandler>(Lifestyle.Scoped);
        container.Register<GetCartHandler>(Lifestyle.Scoped);
        
        // Register with ASP.NET Core DI as well
        builder.Services.AddScoped<AddToCartHandler>(_ => container.GetInstance<AddToCartHandler>());
        builder.Services.AddScoped<GetCartHandler>(_ => container.GetInstance<GetCartHandler>());
        
        // Add Simple Injector integration
        builder.Services.AddSimpleInjector(container, options => {
            options.AddAspNetCore();
        });
        
        var app = builder.Build();
        
        // Configure middleware
        app.UseFastEndpoints();
        
        // Finalize Simple Injector integration
        app.Services.UseSimpleInjector(container);
        
        container.Verify();
        
        app.Run();
    }
}