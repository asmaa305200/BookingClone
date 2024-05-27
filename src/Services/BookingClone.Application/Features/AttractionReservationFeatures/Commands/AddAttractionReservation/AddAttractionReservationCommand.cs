using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;

using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.AddAttractionReservation;

public sealed class AddAttractionReservationCommand : IRequest<GetAttractionReservationDto>
{
    public required AddAttractionReservationDto Dto { get; set; }
}
