using BookingClone.Domain.Enums;

namespace BookingClone.Application.Features.AttractionReservationFeatures.DTOs;

public sealed class UpdateAttractionReservationDto : AddAttractionReservationDto
{
    public int ID { get; set; }

    public ReservationStatus Status { get; set; }
}
