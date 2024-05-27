using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Commands.DeleteRoom;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, int>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<int> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        return await _roomRepository.DeleteAsync(request.ID, cancellationToken);
    }
}
