using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.DeleteHotelReview;

internal sealed class DeleteHotelReviewCommandHandler : IRequestHandler<DeleteHotelReviewCommand, int>
{
    private readonly IHotelReviewRepository _HotelReviewRepository;

    public DeleteHotelReviewCommandHandler(IHotelReviewRepository repository)
        => _HotelReviewRepository = repository;

    public async Task<int> Handle(DeleteHotelReviewCommand request, CancellationToken cancellationToken)
    {
        return await _HotelReviewRepository.DeleteAsync(request.ID, cancellationToken);
    }
}
