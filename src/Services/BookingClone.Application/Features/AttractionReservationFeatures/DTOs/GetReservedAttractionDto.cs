namespace BookingClone.Application.Features.AttractionReservationFeatures.DTOs;

public sealed class GetReservedAttractionDto
{
    public int AttractionID { get; set; }

    public int AttractionReservationID { get; set; }

    public int TicketCount { get; set; }
}