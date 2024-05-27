using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.AddAttractionReview;

public sealed class AddAttractionReviewCommand : IRequest<GetAttractionReviewDto>
{
    public required AddAttractionReviewDto Dto { get; set; }
}


