using System;

using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.DeleteAttractionReview;

public sealed class DeleteAttractionReviewCommand : IRequest<int>
{
    public required int ID { get; set; }
}

