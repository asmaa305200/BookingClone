namespace BookingClone.Domain.Entities;

public sealed class ReservedRoom
{
    public int RoomID { get; set; }

    public int RoomReservationID { get; set; }

    public Room Room { get; set; }

    public RoomReservation RoomReservation { get; set; }

    public int RoomCount { get; set; }
}
