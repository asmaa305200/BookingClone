using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Queries.GetAllRoomReservations;

public sealed class GetAllRoomReservationsQuery : IRequest<PagedList<GetRoomReservationDto>>
{
    public required PaginationQuery Query { get; set; }
}
