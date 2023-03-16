using System;
using System.Threading.Tasks;
using API.Application.Commands.ConfirmOrder;
using API.Application.Commands.DraftOrder;
using API.Application.ViewModels;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    [ProducesResponseType(typeof(OrderViewModel), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetAvailableFlights([FromBody] DraftOrderCommand order)
    {
        var createdDraftOrder = await _mediator.Send(order);
        return new CreatedResult($"/Orders/{createdDraftOrder.Id}/draft",createdDraftOrder);
    }

    [HttpPut]
    [Route("{orderId}/confirm")]
    [ProducesResponseType(typeof(OrderViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailableFlights([FromRoute] Guid orderId)
    {
        var confirmedOrder =  await _mediator.Send(new ConfirmOrderCommand(orderId));
        return Ok(confirmedOrder);
    }
}