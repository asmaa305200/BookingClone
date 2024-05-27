using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetReservedAttractionDetailsById;

public sealed class GetReservedAttractionDetailsByIdQuery : IRequest<GetReservedAttractionDto>
{
    public int ReservationId { get; set; }

    public int AttractionId { get; set; }

    public GetReservedAttractionDetailsByIdQuery(int reservationId, int attractionId)
    {
        ReservationId = reservationId;
        AttractionId = attractionId;
    }
}
