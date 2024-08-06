using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ShoppingCartConfig : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(x => x.Id);


        builder.HasOne(x => x.user)
                .WithOne(x => x.Basket)
                .HasForeignKey<Basket>(e => e.UserId)
                .IsRequired(false);


        //builder.HasMany(x => x.BasketItems)
        //    .WithOne(x => x.Basket)
        //    .HasForeignKey(x => x.BasketId)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}