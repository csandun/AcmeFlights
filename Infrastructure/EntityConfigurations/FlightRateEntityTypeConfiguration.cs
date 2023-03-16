using System;
using Domain.Aggregates.FlightAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class FlightRateEntityTypeConfiguration : BaseEntityTypeConfiguration<FlightRate>
{
    public override void Configure(EntityTypeBuilder<FlightRate> builder)
    {
        base.Configure(builder);

        builder.Property<Guid>("FlightId").IsRequired();

        builder.Property("Name").IsRequired();
        builder.Property("Available").IsRequired();

        builder.OwnsOne(o => o.Price).Property(p => p.Value).HasColumnName("Price_Value");
        builder.OwnsOne(o => o.Price).Property(p => p.Currency).HasColumnName("Price_Currency");
    }
}