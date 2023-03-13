using System;

namespace API.ApiResponses;

public record FlightResponse(string FlightCode, string DepartureAirportCode, string ArrivalAirportCode, DateTimeOffset Departure,
    DateTimeOffset Arrival, decimal PriceFrom);