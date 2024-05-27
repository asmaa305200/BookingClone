using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.DeleteRoomReservation;

public sealed class DeleteRoomReservationCommand : IRequest<int>
{
    public required int ID { get; init; }
}
