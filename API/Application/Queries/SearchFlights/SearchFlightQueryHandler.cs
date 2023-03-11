using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.ApiResponses;
using Domain.Aggregates.FlightAggregate;
using MediatR;

namespace API.Application.Queries.SearchFlights;

public class SearchFlightQueryHandler : IRequestHandler<SearchFlightQuery, IEnumerable<FlightResponse>>
{
    private readonly IFlightRepository _flightRepository;

    public SearchFlightQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<IEnumerable<FlightResponse>> Handle(SearchFlightQuery request, CancellationToken cancellationToken)
    {
        var flights = await _flightRepository.GetAvailableAsync(null, cancellationToken);
        return flights.Select(o => new FlightResponse(
            o.OriginAirportId.ToString(),
            o.DestinationAirportId.ToString(),
            o.Departure,
            o.Arrival,
            o.Rates.Min(p => p.Price.Value))).OrderBy(o => o.PriceFrom);
    }
}