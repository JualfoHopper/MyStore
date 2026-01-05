using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MyStore.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>(e =>
        {
            e.HasKey("CategoryId");
            e.Property(c => c.Name).IsRequired();
            e.Property("CategoryId").ValueGeneratedOnAdd();
            e.HasData(
                new Category { CategoryId = 1, Name = "Technology" },
                new Category { CategoryId = 2, Name = "Bedroom" },
                new Category { CategoryId = 3, Name = "Clothing" }
            );
        });
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey("UserId");
            e.Property("UserId").ValueGeneratedOnAdd();

        });
        modelBuilder.Entity<Order>(e =>
        {
            e.HasKey("OrderId");
            e.Property("OrderId").ValueGeneratedOnAdd();
            e.Property("TotalAmount").HasColumnType("decimal(10/2)");
            e.HasOne(e => e.User).WithMany(p => p.Orders).HasForeignKey(p => p.UserId).
            OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<OrderItem>(e =>
        {
            e.HasKey("OrderItemId");
            e.Property("OrderItemId").ValueGeneratedOnAdd();
            e.Property("Price").HasColumnType("decimal(10/2)");
            e.HasOne(e => e.Order).WithMany(p => p.OrderItems).HasForeignKey(p => p.OrderId).
            OnDelete(DeleteBehavior.Restrict);
            e.HasOne(e => e.Product).WithMany().HasForeignKey(p => p.ProductId).
            OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Product>(e =>
        {
            e.HasKey("ProductId");
            e.Property(c => c.Name).IsRequired();
            e.Property("ProductId").ValueGeneratedOnAdd();
            e.Property("Price").HasColumnType("decimal(10/2)");
            e.HasOne<Category>(c => c.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId).
            OnDelete(DeleteBehavior.Restrict);
        });
    }
}
//Creación de la migració inicial y actualització de la base de dades
//PM> Add-Migration firstMigration
//PM> Update-Database