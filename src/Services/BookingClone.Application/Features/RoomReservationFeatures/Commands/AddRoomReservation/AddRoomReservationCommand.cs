using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.AddRoomReservation;

public sealed class AddRoomReservationCommand : IRequest<GetRoomReservationDto>
{
    public required AddRoomReservationDto Dto { get; set; }
}
