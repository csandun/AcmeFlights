using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class OrderEntityConfiguration : BaseEntityTypeConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        
        builder.Property("OrderDraftedDateTime").IsRequired();
        builder.Property("OrderCreatedDateTime");
        builder.Property("Status")
            .IsRequired()
            .HasConversion<int>();

        var navigation = builder.Metadata.FindNavigation(nameof(Order.LineItems));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

    }
}