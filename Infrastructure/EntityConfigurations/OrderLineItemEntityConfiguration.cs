using System;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class OrderLineItemEntityConfiguration : BaseEntityTypeConfiguration<OrderLineItem>
{
    public override void Configure(EntityTypeBuilder<OrderLineItem> builder)
    {
        base.Configure(builder);

        builder.Property("Quantity").IsRequired();
        
        builder
            .HasOne<Order>()
            .WithOne()
            .IsRequired()
            .HasForeignKey("OrderId");
        
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
        
        builder.OwnsOne(o => o.Price, a =>
        {
            a.Property<Guid>("OrderLineItemId");
            a.WithOwner();
        });
    }
}