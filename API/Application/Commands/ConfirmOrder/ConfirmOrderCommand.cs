using System;
using System.Collections.Generic;
using API.Application.ViewModels;
using Domain.Aggregates.OrderAggregate;
using MediatR;

namespace API.Application.Commands.ConfirmOrder;

public record ConfirmOrderCommand(Guid OrderId) : IRequest<Unit>;
