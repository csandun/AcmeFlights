using System.Threading;
using System.Threading.Tasks;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace API.Application.Commands;

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, AirportViewModel>
{
    private readonly IAirportRepository _airportRepository;
    private readonly IMapper _mapper;

    public CreateAirportCommandHandler(IAirportRepository airportRepository, IMapper mapper)
    {
        _airportRepository = airportRepository;
        _mapper = mapper;
    }

    public async Task<AirportViewModel> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = _airportRepository.Add(new Airport(request.Code, request.Name));

        await _airportRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return _mapper.Map<AirportViewModel>(airport);
        
    }
}