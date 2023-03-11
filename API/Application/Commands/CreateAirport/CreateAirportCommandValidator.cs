using API.Application.Commands;
using FluentValidation;

namespace API.Application.Commands;

public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
{
    public CreateAirportCommandValidator()
    {
        RuleFor(c => c.Code).NotEmpty().Length(3);
        RuleFor(c => c.Name).NotEmpty();
    }
}