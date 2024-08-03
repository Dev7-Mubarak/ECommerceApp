using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ShoppingCartConfig : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(x => x.Id);

       

        builder.HasOne(x => x.user)
                .WithOne(x => x.shoppingCart)
                .HasForeignKey<Basket>(e => e.UserId)
                .IsRequired(false);



        builder.HasMany(x => x.catItems)
            .WithOne(x => x.cart)
            .HasForeignKey(x => x.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

       
    }
}