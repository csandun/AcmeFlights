using System;
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
        
        builder.Property("Quantity").IsRequired();
        builder.Property("OrderDraftedDateTime").IsRequired();
        builder.Property("OrderCreatedDateTime");
        builder.Property("Status")
            .IsRequired()
            .HasConversion<int>();

        builder
            .HasOne<Flight>()
            .WithOne()
            .IsRequired()
            .HasForeignKey("FlightId");

        builder
            .HasOne<FlightRate>()
            .WithOne()
            .IsRequired()
            .HasForeignKey("FlightRateId");
            
    }
}