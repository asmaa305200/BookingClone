using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Queries.GetAllRoomReservations;

public sealed class GetAllAttractionReservationsQuery : IRequest<PagedList<GetAttractionReservationDto>>
{
    public required PaginationQuery Query { get; set; }
}
