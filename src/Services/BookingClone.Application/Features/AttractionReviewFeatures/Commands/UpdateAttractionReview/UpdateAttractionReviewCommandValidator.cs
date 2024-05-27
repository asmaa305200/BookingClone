using System;

using FluentValidation;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.UpdateAttractionReview;

internal sealed class UpdateAttractionReviewCommandValidator : AbstractValidator<UpdateAttractionReviewCommand>
{
    public UpdateAttractionReviewCommandValidator()
    {

    }
}

