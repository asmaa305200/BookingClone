using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.DeleteRoomReservation;

internal sealed class DeleteRoomReservationCommandHandler : IRequestHandler<DeleteRoomReservationCommand, int>
{
    private readonly IRoomReservationRepository _RoomReservationRepository;

    public DeleteRoomReservationCommandHandler(IRoomReservationRepository repository)
        => _RoomReservationRepository = repository;

    public async Task<int> Handle(DeleteRoomReservationCommand request, CancellationToken cancellationToken)
    {
        return await _RoomReservationRepository.DeleteAsync(request.ID, cancellationToken);
    }
}
