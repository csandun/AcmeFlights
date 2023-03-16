using System;
using API.Application.ViewModels;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.ConfirmOrder;

public record ConfirmOrderCommand(Guid OrderId) : IRequest<OrderViewModel>;