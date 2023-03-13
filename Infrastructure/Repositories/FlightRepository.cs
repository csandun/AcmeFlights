using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly FlightsContext _context;

    public FlightRepository(FlightsContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Flight Add(Flight flight)
    {
        return _context.Flights.Add(flight).Entity;
    }

    public void Update(Flight flight)
    {
        _context.Flights.Update(flight);
    }

    public async Task<Flight> GetAsync(Guid flightId)
    {
        return await _context.Flights
            .Include(o => o.Rates)
            .FirstOrDefaultAsync(o => o.Id == flightId);
    }

    public async Task<IList<Flight>> GetAvailableAsync(string destination = null,
        CancellationToken cancellationToken = default)
    {
        // considering null for now
        return await _context.Flights
            .Include(o => o.Rates)
            .Where(o => o.Rates.Any(p => p.Available > 0))
            .ToListAsync(cancellationToken);
    }

    public async Task<Flight> GetFlightsWithSelectedRateAsync(Guid flightId, Guid flightRateId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Flights
            .Include(o => o.Rates)
            .FirstOrDefaultAsync(o => o.Id == flightId, cancellationToken);
    }

    public void UpdateFlightRate(FlightRate flightRate)
    {
        _context.FlightRates.Update(flightRate);
    }
}