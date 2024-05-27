using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAttractionReviewById;

public class GetAttractionReviewByIdQuery : IRequest<GetAttractionReviewDto?>
{
    public required int ID { get; init; }
}

