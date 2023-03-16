using API.Application.ViewModels;
using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace API.Application.Commands;

public class CreateAirportCommand : IRequest<AirportViewModel>
{
    public CreateAirportCommand(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; }

    public string Name { get; }
}