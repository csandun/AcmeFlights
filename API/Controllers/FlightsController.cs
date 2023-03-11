using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    [HttpGet]
    [Route("Search")]
    public Task<IEnumerable<FlightResponse>> GetAvailableFlights()
    {
        throw new NotImplementedException();
    }
}