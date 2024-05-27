namespace BookingClone.Domain.Entities;

public sealed class AttractionReservation : Reservation
{
    public DateTimeOffset TourStart { get; set; }

    public List<ReservedAttraction> ReservedAttractions { get; set; }
}
