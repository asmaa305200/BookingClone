using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.UpdateAttractionReview;

public sealed class UpdateAttractionReviewCommand : IRequest<GetAttractionReviewDto?>
{
    public required UpdateAttractionReviewDto Dto { get; set; }
}

