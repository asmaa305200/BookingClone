using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Domain.Common;

using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAllAttractionReviews;

public sealed class GetAllAttractionReviewsQuery : IRequest<PagedList<GetAttractionReviewDto>>
{
    public required PaginationQuery Query { get; set; }
}