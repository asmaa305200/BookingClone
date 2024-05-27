using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.DeleteAttractionReservation;

public sealed class DeleteAttractionReservationCommand : IRequest<int>
{
    public required int ID { get; init; }
}
