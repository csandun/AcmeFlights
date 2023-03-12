using Domain.Aggregates.FlightAggregate;
using MediatR;

namespace Domain.Events;

public class FlightRateAvailabilityChangedEvent : INotification
{
    public FlightRateAvailabilityChangedEvent(Flight flight, FlightRate flightRate, int mutation)
    {
        Flight = flight;
        FlightRate = flightRate;
        Mutation = mutation;
    }

    public Flight Flight { get; }
    public FlightRate FlightRate { get; }
    public int Mutation { get; }
}