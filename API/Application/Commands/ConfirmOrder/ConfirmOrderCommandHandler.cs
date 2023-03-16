using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace API.Application.Commands.ConfirmOrder;

public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, OrderViewModel>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;

    public ConfirmOrderCommandHandler(IFlightRepository flightRepository, IOrderRepository orderRepository,
        IMapper mapper, IMediator mediator)
    {
        _flightRepository = flightRepository;
        _orderRepository = orderRepository;
        _mediator = mediator;
    }

    public async Task<OrderViewModel> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        // get existing order from the order id
        var order = await _orderRepository.GetAsync(request.OrderId);
        
        // if order cannot find and order lines are empty cannot confirm order. then throws exceptions
        if (order is null) throw new ArgumentException("Cannot find your order record");

        if (!order.LineItems.ToList().Any()) throw new ArgumentException("You cannot confirm without line items");

        // confirm the order DDD manner; When confirming,  status and order availabilty are guarded by Domain.
        order.Confirm();

        // process order items and reduce availability for each flight ratings
        foreach (var orderItem in order.LineItems)
        {
            var flight = await _flightRepository.GetFlightsWithSelectedRateAsync(orderItem.FlightId,
                orderItem.FlightRateId, cancellationToken);

            if (flight is null) throw new ArgumentException("Cannot find order item in current order.");

            var rate = flight.GetRate(orderItem.FlightRateId);

            //When an order is confirmed, the any ordered rates should lower their availability by the quantity ordered
            rate.MutateAvailability(orderItem.Quantity * -1);

            _flightRepository.UpdateFlightRate(rate);
        }

        await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        // Notifies the customer about the confirmed order 
        await _mediator.Publish(new OrderConfirmNotification(order), cancellationToken);

        return new OrderViewModel(order.Id, Enum.GetName(typeof(OrderStatus), order.Status));
    }
}