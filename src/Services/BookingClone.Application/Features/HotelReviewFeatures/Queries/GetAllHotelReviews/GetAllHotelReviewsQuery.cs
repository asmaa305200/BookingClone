using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Domain.Common;

using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Queries.GetAllHotelReviews;

public sealed class GetAllHotelReviewsQuery : IRequest<PagedList<GetHotelReviewDto>>
{
    public required PaginationQuery Query { get; set; }
}