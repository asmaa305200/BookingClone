using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetAttractionReservationById;

public sealed class GetAttractionReservationByIdQuery : IRequest<GetAttractionReservationDto?>
{
    public required int ID { get; init; }
}
