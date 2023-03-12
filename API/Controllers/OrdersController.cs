using System;
using System.Threading.Tasks;
using API.Application.Commands.ConfirmOrder;
using API.Application.Commands.DraftOrder;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("draft")]
    public async Task<Order> GetAvailableFlights([FromBody] DraftOrderCommand order)
    {
        return await _mediator.Send(order);
    }

    [HttpPut]
    [Route("{orderId}/confirm")]
    public async Task<Unit> GetAvailableFlights([FromRoute] Guid orderId)
    {
        return await _mediator.Send(new ConfirmOrderCommand(orderId));
    }
}