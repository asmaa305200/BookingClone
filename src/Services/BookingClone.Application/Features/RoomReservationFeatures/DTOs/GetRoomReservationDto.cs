using BookingClone.Domain.Enums;

namespace BookingClone.Application.Features.RoomReservationFeatures.DTOs;

public sealed class GetRoomReservationDto
{
    public int ID { get; set; }

    public decimal TotalCost { get; set; }

    public ReservationStatus Status { get; set; }

    public DateTimeOffset CheckIn { get; set; }

    public DateTimeOffset CheckOut { get; set; }
}
