using Domain.Aggregates.FlightAggregate;
using MediatR;

namespace Domain.Events;

public class FlightRatePriceChangedEvent : INotification
{
    public FlightRatePriceChangedEvent(Flight flight, FlightRate flightRate)
    {
        Flight = flight;
        FlightRate = flightRate;
    }

    public Flight Flight { get; }
    public FlightRate FlightRate { get; }
}