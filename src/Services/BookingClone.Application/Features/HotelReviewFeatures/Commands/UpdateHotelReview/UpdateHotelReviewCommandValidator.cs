using System;

using FluentValidation;

namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.UpdateHotelReview;

internal sealed class UpdateHotelReviewCommandValidator :AbstractValidator<UpdateHotelReviewCommand>
{
    public UpdateHotelReviewCommandValidator()
    {

    }
}

