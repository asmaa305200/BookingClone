using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.UpdateHotelReview;

public sealed class UpdateHotelReviewCommand : IRequest<GetHotelReviewDto?>
{
    public required UpdateHotelReviewDto Dto { get; set; }
}

