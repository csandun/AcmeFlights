using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Domain.Events;

public class DraftedOrderQuantityChangedEvent :  INotification
{
    public Order Order { get; private set; }
    public int Quantity { get; private set; }

    public DraftedOrderQuantityChangedEvent(Order order, int quantity)
    {
        order = order;
        quantity = quantity;
    }
}