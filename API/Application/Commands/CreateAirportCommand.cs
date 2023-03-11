using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace API.Application.Commands;

public class CreateAirportCommand : IRequest<Airport>
{
    public CreateAirportCommand(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; }

    public string Name { get; }
}