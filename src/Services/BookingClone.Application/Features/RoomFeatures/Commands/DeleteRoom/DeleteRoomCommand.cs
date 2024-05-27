using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Commands.DeleteRoom;

public sealed class DeleteRoomCommand : IRequest<int>
{
    public required int ID { get; init; }
}
