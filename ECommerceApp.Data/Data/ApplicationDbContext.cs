using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Address> addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ProductImageDto> ProductImages { get; set; }
    public DbSet<Basket> Basket {  get; set; }
    public DbSet<BasketItem> CartItems { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // إضافة التكوين هنا
        builder.Entity<Basket>()
            .HasOne(s => s.user)
            .WithOne(u => u.shoppingCart)
            .HasForeignKey<Basket>(s => s.UserId)
            .IsRequired(false);

        // تطبيق التكوينات الأخرى
        //builder.ApplyConfiguration(new ShoppingCartConfig());
    }

}
