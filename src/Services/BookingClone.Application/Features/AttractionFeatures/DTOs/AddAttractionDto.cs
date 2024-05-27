namespace BookingClone.Application.Features.AttractionFeatures.DTOs;

public class AddAttractionDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int AvailableTickets { get; set; }

    public decimal TicketPrice { get; set; }

    public string Duration { get; set; }
}
