using BookingClone.Application.Features.HotelFeatures.DTOs;
using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.Queries.GetAll;

public class GetAllHotelsQuery : IRequest<PagedList<GetHotelsDto>>
{
    public required PaginationQuery Query { get; set; }
}
