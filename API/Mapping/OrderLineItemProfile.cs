using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;

namespace API.Mapping;

public class OrderLineItemProfile: Profile
{
    public OrderLineItemProfile()
    {
        CreateMap<OrderItemLineViewModel, OrderLineItem>();
    }
}