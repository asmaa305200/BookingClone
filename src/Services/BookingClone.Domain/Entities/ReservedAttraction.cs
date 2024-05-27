namespace BookingClone.Domain.Entities;

public sealed class ReservedAttraction
{
    public int AttractionID { get; set; }
    
    public int AttractionReservationID { get; set; }

    public Attraction Attraction { get; set; }
    
    public AttractionReservation AttractionReservation { get; set; }

    public int TicketCount { get; set; }
}
