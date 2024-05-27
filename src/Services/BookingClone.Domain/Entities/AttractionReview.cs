namespace BookingClone.Domain.Entities;

public sealed class AttractionReview : Review
{
    public string Comment { get; set; }

    public int AttractionID { get; set; }

    public Attraction Attraction { get; set; }
}
