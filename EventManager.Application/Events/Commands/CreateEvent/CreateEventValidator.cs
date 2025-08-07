using FluentValidation;

namespace EventManager.Application.Events.Commands.CreateEvent;

public class CreateEventValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título do evento é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.Date)
            .GreaterThan(DateTime.UtcNow).WithMessage("A data deve ser no futuro.");

        RuleFor(x => x.SpeakerId)
            .NotEqual(Guid.Empty).WithMessage("Informe um palestrante.");

        RuleFor(x => x.TotalSeats)
            .GreaterThan(0).WithMessage("Total de vagas deve ser maior que 0.");
    }
}
