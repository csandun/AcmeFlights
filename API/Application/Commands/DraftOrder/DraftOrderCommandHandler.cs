using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.DraftOrder;

public class DraftOrderCommandHandler : IRequestHandler<DraftOrderCommand, Order>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public DraftOrderCommandHandler(IFlightRepository flightRepository, IOrderRepository orderRepository,
        IMapper mapper)
    {
        _flightRepository = flightRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Order> Handle(DraftOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.CreateOrder();

        foreach (var orderItem in request.OrderItemLines)
        {
            var flight = await _flightRepository.GetFlightsWithSelectedRateAsync(orderItem.FlightId,
                orderItem.FlightRateId, cancellationToken);

            if (flight is null) throw new ArgumentException("Cannot find order item in current order.");

            var rate = flight.GetRate(orderItem.FlightRateId);

            order.AddLineItem(orderItem.FlightId,
                orderItem.FlightRateId,
                rate.Price,
                orderItem.Quantity, rate.Available);
        }
        
        await _orderRepository.AddAsync(order);
        
        await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return order;
    }
}