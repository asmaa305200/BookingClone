using FluentValidation;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.AddRoomReservation;

internal sealed class AddRoomReservationCommandValidator : AbstractValidator<AddRoomReservationCommand>
{
    public AddRoomReservationCommandValidator()
    {
        RuleFor(x => x.Dto.CheckIn)
            .GreaterThan(DateTimeOffset.UtcNow).WithMessage("The Check in should be in the future.");

        RuleFor(x => x.Dto.CheckOut)
            .GreaterThan(DateTimeOffset.UtcNow).WithMessage("The Check out should be in the future.");

        RuleFor(x => x.Dto.TotalCost)
            .GreaterThan(0).WithMessage("The Total cost should be greater than zero.");
    }
}
