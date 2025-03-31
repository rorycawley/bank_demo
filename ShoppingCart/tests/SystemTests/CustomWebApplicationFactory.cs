using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleInjector.Lifestyles;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHostBuilder CreateHostBuilder()
    {
        // Create a completely custom host builder that doesn't use Program.cs
        return Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<TestStartup>()
                    .UseTestServer();
            });
    }
}

// Custom Startup class specifically for testing
public class TestStartup
{
    private readonly Container _container;

    public TestStartup()
    {
        _container = new Container();
        _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Register services in the container
        // Change to Singleton lifestyle for testing to avoid scoping issues
        _container.Register<ICartRepository, CartRepository>(Lifestyle.Singleton);
        _container.Register<ICartQueryService, CartQueryService>(Lifestyle.Singleton);
        _container.Register<AddToCartHandler>(Lifestyle.Singleton);
        _container.Register<GetCartHandler>(Lifestyle.Singleton);

        // Add routing and controllers (required for endpoint routing)
        services.AddRouting();
        services.AddControllers();
        
        // Register FastEndpoints
        services.AddFastEndpoints();
        
        // Add Simple Injector
        services.AddSimpleInjector(_container, options =>
        {
            options.AddAspNetCore();
            
            // Important: Enable auto-verification to prevent container verification issues
            options.AutoCrossWireFrameworkComponents = true;
        });
        
        // Register handlers in ASP.NET Core DI container as singleton
        services.AddSingleton<AddToCartHandler>(sp => _container.GetInstance<AddToCartHandler>());
        services.AddSingleton<GetCartHandler>(sp => _container.GetInstance<GetCartHandler>());
        
        // Manually scan and register all endpoints
        services.AddSingleton<WebApi.Endpoints.AddToCartEndpoint>();
        services.AddSingleton<WebApi.Endpoints.GetCartEndpoint>();
    }

    public void Configure(IApplicationBuilder app)
    {
        // First, ensure Simple Injector integration
        app.UseSimpleInjector(_container);

        // Configure the application with proper routing
        app.UseRouting();
        
        // Map endpoints - this must come after UseRouting
        app.UseEndpoints(endpoints =>
        {
            // This sets up the IEndpointRouteBuilder that FastEndpoints needs
            endpoints.MapControllers();
            
            // Use FastEndpoints within the endpoints configuration
            endpoints.MapFastEndpoints();
        });
        
        // Verify container
        _container.Verify();
    }
}