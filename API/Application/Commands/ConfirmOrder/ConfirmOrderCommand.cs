using System;
using MediatR;

namespace API.Application.Commands.ConfirmOrder;

public record ConfirmOrderCommand(Guid OrderId) : IRequest<Unit>;