using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.DeleteAttractionReservation;

internal sealed class DeleteAttractionReservationCommandHandler : IRequestHandler<DeleteAttractionReservationCommand, int>
{
    private readonly IAttractionReservationRepository _attractionReservationRepository;

    public DeleteAttractionReservationCommandHandler(IAttractionReservationRepository repository)
        => _attractionReservationRepository = repository;

    public async Task<int> Handle(DeleteAttractionReservationCommand request, CancellationToken cancellationToken)
    {
        return await _attractionReservationRepository.DeleteAsync(request.ID, cancellationToken);
    }
}
