using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.AddHotelReview;

public sealed class AddHotelReviewCommand : IRequest<GetHotelReviewDto>
{
    public required AddHotelReviewDto Dto { get; set; }
}

