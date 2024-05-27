using BookingClone.Domain.Contracts;

using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.DeleteAttractionReview;

internal sealed class DeleteAttractionReviewCommandHandler : IRequestHandler<DeleteAttractionReviewCommand, int>
{
    private readonly IAttractionReviewRepository _AttractionReviewRepository;

    public DeleteAttractionReviewCommandHandler(IAttractionReviewRepository repository)
        => _AttractionReviewRepository = repository;

    public async Task<int> Handle(DeleteAttractionReviewCommand request, CancellationToken cancellationToken)
    {
        return await _AttractionReviewRepository.DeleteAsync(request.ID, cancellationToken);
    }
}
