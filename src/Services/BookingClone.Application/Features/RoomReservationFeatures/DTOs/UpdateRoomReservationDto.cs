using BookingClone.Domain.Enums;

namespace BookingClone.Application.Features.RoomReservationFeatures.DTOs;

public sealed class UpdateRoomReservationDto : AddRoomReservationDto
{
    public int ID { get; set; }

    public ReservationStatus Status { get; set; }
}
