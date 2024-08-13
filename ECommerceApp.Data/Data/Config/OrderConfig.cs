using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                x => (int)x,
                x => (Status) x
            );


        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);


        builder.HasOne(x => x.Payment)
             .WithOne(x => x.Order)
             .HasForeignKey<Order>(x => x.PaymentId);

    }
}

