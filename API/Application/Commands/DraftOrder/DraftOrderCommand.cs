using System;
using System.Collections.Generic;
using API.Application.ViewModels;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.DraftOrder;

public class DraftOrderCommand: IRequest<Order>
{
   public List<OrderItemLineViewModel>  OrderItemLines { get; set; }
}