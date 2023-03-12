using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate;

public interface IFlightRepository
{
    Flight Add(Flight flight);

    void Update(Flight flight);

    Task<Flight> GetAsync(Guid flightId);

    Task<IList<Flight>> GetAvailableAsync(string destination = null, CancellationToken cancellationToken = default);

    Task<Flight> GetFlightsWithSelectedRateAsync(Guid flightId, Guid flightRateId,
        CancellationToken cancellationToken = default);

    void UpdateFlightRate(FlightRate flightRate);
}