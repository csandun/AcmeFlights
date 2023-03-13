using System;
using Domain.Common;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate;

public class OrderLineItem : Entity
{
    private OrderLineItem()
    {
    }

    public Guid OrderId { get; private set; }
    public Guid FlightId { get; private set; }
    public Guid FlightRateId { get; private set; }
    public int Quantity { get; private set; }
    public Price Price { get; private set; }

    // I am preferring to use static factory method for creating DDD objects because of the encapsulating creating process.
    public static OrderLineItem CreateOrderItem(Guid orderId, Guid flightId, Guid flightRateId, Price price,
        int quantity)
    {
        return new OrderLineItem
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            FlightId = flightId,
            FlightRateId = flightRateId,
            Quantity = quantity,
            Price = price
        };
    }
    
    public void MutateQuantity(int quantity)
    {
        Quantity += quantity;
    }
}