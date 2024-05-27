using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Queries.GetRoomReservationById;

public sealed class GetRoomReservationByIdQuery : IRequest<GetRoomReservationDto?>
{
    public required int ID { get; init; }
}
