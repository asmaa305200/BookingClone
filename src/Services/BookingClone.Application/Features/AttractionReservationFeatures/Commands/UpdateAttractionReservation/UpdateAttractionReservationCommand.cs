using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.UpdateAttractionReservation;

public sealed class UpdateAttractionReservationCommand : IRequest<GetAttractionReservationDto?>
{
    public required UpdateAttractionReservationDto Dto { get; set; }
}
