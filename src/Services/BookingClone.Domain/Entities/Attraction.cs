using BookingClone.Domain.Common;

namespace BookingClone.Domain.Entities;

public sealed class Attraction : BaseEntity<int>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int AvailableTickets { get; set; }

    public decimal TicketPrice { get; set; }

    public string Duration { get; set; }

    public City? City { get; set; }

    public List<AttractionReview> Reviews { get; set; }

    public List<ReservedAttraction> ReservedAttractions { get; set; }

    public List<AttractionImage> Images { get; set; }
}
