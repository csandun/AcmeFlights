using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Aggregates.AirportAggregate;
using Infrastructure;

namespace API.Infrastructure.Seeds;

public class AirportsSeeder : FlightsContextSeeder
{
    public AirportsSeeder(FlightsContext flightsContext) : base(flightsContext)
    {
    }

    public override void Seed()
    {
        if (FlightsContext.Airports.Any())
        {
            Console.WriteLine("Skipping Airports seeder because table is not empty.");
            return;
        }

        var airports = new List<Airport>
        {
            new("AMS", "Amsterdam Airport Schiphol"),
            new("FRA", "Frankfurt am Main Airport"),
            new("LHR", "London Heathrow Airport"),
            new("BCN", "Barcelona International Airport"),
            new("CDG", "Charles de Gaulle International"),
            new("IST", "Istanbul Airport"),
            new("MUC", "Munich Airport"),
            new("ZRH", "Zurich Airport"),
            new("DUB", "Dublin Airport"),
            new("FCO", "Rome Fiumicino Airport"),
            new("ARN", "Stockholm Arlanda Airport"),
            new("CPH", "Copenhagen Airport")
        };

        FlightsContext.Airports.AddRange(airports);
        FlightsContext.SaveChanges();
    }
}