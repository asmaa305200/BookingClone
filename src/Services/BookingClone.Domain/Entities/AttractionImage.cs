namespace BookingClone.Domain.Entities;

public sealed class AttractionImage
{
    public int ID { get; set; }

    public string ImageUrlPath { get; set; }

    public Attraction Attraction { get; set; }
}
