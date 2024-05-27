namespace BookingClone.Application.Features.RoomReservationFeatures.DTOs;

public class AddRoomReservationDto
{
    public decimal TotalCost { get; set; }

    public DateTimeOffset CheckIn { get; set; }

    public DateTimeOffset CheckOut { get; set; }
}
