namespace BookingClone.Domain.Entities;

public sealed class RoomReservation : Reservation
{
    public DateTimeOffset CheckIn { get; set; }
    
    public DateTimeOffset CheckOut { get; set; }

    public List<ReservedRoom> ReservedRooms { get; set; }
}
