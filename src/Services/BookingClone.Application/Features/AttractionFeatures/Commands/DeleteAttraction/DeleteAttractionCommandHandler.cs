using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.DeleteAttraction;

internal sealed class DeleteAttractionCommandHandler : IRequestHandler<DeleteAttractionCommand, int>
{
    private readonly IAttractionRepository _attractionRepository;

    public DeleteAttractionCommandHandler(IAttractionRepository repository)
        => _attractionRepository = repository;

    public async Task<int> Handle(DeleteAttractionCommand request, CancellationToken cancellationToken)
    {
        return await _attractionRepository.DeleteAsync(request.ID, cancellationToken);
    }
}
