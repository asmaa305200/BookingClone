using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.DeleteHotelReview;

public sealed class DeleteHotelReviewCommand : IRequest<int>
{
    public required int ID { get; set; }
}

