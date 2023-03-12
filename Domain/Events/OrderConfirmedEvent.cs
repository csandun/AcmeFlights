using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Domain.Events;

public class OrderConfirmedEvent:  INotification
{
    public Order Order { get; private set; }
    
    public OrderConfirmedEvent(Order order)
    {
        order = order;
    }
}