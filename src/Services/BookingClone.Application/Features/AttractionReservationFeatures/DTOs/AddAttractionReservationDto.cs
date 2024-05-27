namespace BookingClone.Application.Features.AttractionReservationFeatures.DTOs;

public class AddAttractionReservationDto
{
    public decimal TotalCost { get; set; }

    public DateTimeOffset TourStart { get; set; }
}
