using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Queries.GetPaginatedAttractions;

public sealed class GetPaginatedAttractionsQuery : IRequest<PagedList<GetAttractionDto>>
{
    public required PaginationQuery Query { get; set; }
}
