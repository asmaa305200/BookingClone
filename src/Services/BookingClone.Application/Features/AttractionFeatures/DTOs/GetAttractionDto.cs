namespace BookingClone.Application.Features.AttractionFeatures.DTOs;

public sealed class GetAttractionDto
{
    public int ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int AvailableTickets { get; set; }

    public decimal TicketPrice { get; set; }

    public string Duration { get; set; }

    public List<AttractionImageDto> Images { get; set; }

}
