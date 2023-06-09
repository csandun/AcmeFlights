using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries.SearchFlights;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("search-available-flightrates")]
    [ProducesResponseType(typeof(IEnumerable<FlightResponse>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<FlightResponse>> GetAvailableFlights()
    {
        var flights = await _mediator.Send(new SearchFlightQuery());
        return flights;
    }
}