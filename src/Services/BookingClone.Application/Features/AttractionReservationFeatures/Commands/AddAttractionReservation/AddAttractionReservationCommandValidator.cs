using FluentValidation;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.AddAttractionReservation;

internal sealed class AddAttractionReservationCommandValidator : AbstractValidator<AddAttractionReservationCommand>
{
    public AddAttractionReservationCommandValidator()
    {
        RuleFor(x => x.Dto.TourStart)
            .GreaterThan(DateTimeOffset.UtcNow).WithMessage("The Tour Start should be in the future.");

        RuleFor(x => x.Dto.TotalCost)
            .GreaterThan(0).WithMessage("The Total cost should be greater than zero.");
    }
}
