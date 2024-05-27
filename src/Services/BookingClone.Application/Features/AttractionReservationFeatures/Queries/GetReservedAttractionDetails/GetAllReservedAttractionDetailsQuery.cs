using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;

using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetReservedAttractionDetails;

public sealed class GetAllReservedAttractionDetailsQuery : IRequest<List<GetReservedAttractionDto>>
{
    public required int ReservationId { get; set; }
}
