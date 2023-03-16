using System;
using System.Threading;
using System.Threading.Tasks;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.DraftOrder;

public class DraftOrderCommandHandler : IRequestHandler<DraftOrderCommand, OrderViewModel>
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

    public async Task<OrderViewModel> Handle(DraftOrderCommand request, CancellationToken cancellationToken)
    {
        // create drafted order object from the domain class
        var order = Order.CreateOrder();
        
        foreach (var orderItem in request.OrderItemLines)
        {
            // gets available flight with selected rates 
            var flight = await _flightRepository.GetFlightsWithSelectedRateAsync(orderItem.FlightId,
                orderItem.FlightRateId, cancellationToken);

            if (flight is null) throw new ArgumentException("Cannot find order item in current order.");

            // flight rate from the flight object from the DDD manner
            var rate = flight.GetRate(orderItem.FlightRateId);

            // Add selected flight rates for the order as order lines using DDD. 
            order.AddLineItem(orderItem.FlightId,
                orderItem.FlightRateId,
                rate.Price,
                orderItem.Quantity, rate.Available);
        }
        
        await _orderRepository.AddAsync(order);
        
        await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new OrderViewModel(order.Id, Enum.GetName(typeof(OrderStatus), order.Status));
    }
}