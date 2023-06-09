﻿using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Domain.Events;

public class OrderConfirmedEvent : INotification
{
    public OrderConfirmedEvent(Order order)
    {
        order = order;
    }

    public Order Order { get; private set; }
}