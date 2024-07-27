using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasConversion(
                x => (int)x,
                x => (Status)x
            );


        builder.Property(x => x.PaymentMethod)
           .HasConversion(
               x => (int)x,
               x => (PaymentMethod)x
           );




    }
}

