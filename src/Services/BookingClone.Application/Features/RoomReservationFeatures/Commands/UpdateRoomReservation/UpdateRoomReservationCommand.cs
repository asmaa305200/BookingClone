using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.UpdateRoomReservation;

public sealed class UpdateRoomReservationCommand : IRequest<GetRoomReservationDto?>
{
    public required UpdateRoomReservationDto Dto { get; set; }
}
