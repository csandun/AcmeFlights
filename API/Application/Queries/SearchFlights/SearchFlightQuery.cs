using System.Collections.Generic;
using API.ApiResponses;
using MediatR;

namespace API.Application.Queries.SearchFlights;

public record class SearchFlightQuery(string Destination = null): IRequest<IEnumerable<FlightResponse>>;