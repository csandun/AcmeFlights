﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using Domain.Events;
using Domain.Exceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
    public DateTimeOffset OrderCreatedDateTime { get; private set; } = DateTimeOffset.Now;
    public DateTimeOffset OrderDraftedDateTime { get; private set; }
    public OrderStatus Status { get; private set; } = OrderStatus.Draft;

    private readonly List<OrderLineItem> _lineItems;
    public IReadOnlyCollection<OrderLineItem> LineItems => _lineItems;

    private Order()
    {
        _lineItems = new List<OrderLineItem>();
    }

    // I am preferring to use static factory method for creating DDD objects because of the encapsulating creating process.
    // That's why i used private constructor
    public static Order CreateOrder()
    {
        var order = new Order
        {
            Id = Guid.NewGuid()
        };
        return order;
    }

    public void Confirm()
    {
        // Its not possible to make changes to a confirmed order (guarded by domain)
        if (Status != OrderStatus.Draft)
        {
            throw new OrderDomainException("Order already confirmed. Cannot update order status anymore.");
        }

        Status = OrderStatus.Completed;
        OrderCreatedDateTime = DateTimeOffset.Now;
        AddDomainEvent(new OrderConfirmedEvent(this));
    }

    public void AddLineItem(Guid flightId, Guid flightRateId, Price price, int quantity, int availablity)
    {
        //Its not possible to make changes to a confirmed order (guarded by domain)
        if (Status == OrderStatus.Completed)
        {
            throw new OrderDomainException("Order already confirmed. Cannot update order anymore");
        }

        if (availablity < quantity)
        {
            throw new OrderDomainException("Cannot add item to order because there has not availablity of the flight");
        }
        
        var lineItem = OrderLineItem.CreateOrderItem(
            Id,
            flightId,
            flightRateId,
            price,
            quantity
        );
        
        _lineItems.Add(lineItem);
    }
}