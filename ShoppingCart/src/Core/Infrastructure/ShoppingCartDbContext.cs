using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure;

public class ShoppingCartDbContext : DbContext
{
    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
        : base(options) { }

    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<CartItemEntity> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartEntity>().HasKey(c => c.CartId);
        modelBuilder.Entity<CartItemEntity>().HasKey(ci => new { ci.CartId, ci.ProductId });

        modelBuilder.Entity<CartEntity>()
            .HasMany(c => c.Items)
            .WithOne()
            .HasForeignKey(ci => ci.CartId);
    }
}

public class CartEntity
{
    public Guid CartId { get; set; }
    public List<CartItemEntity> Items { get; set; } = [];
}

public class CartItemEntity
{
    public Guid CartId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
}
