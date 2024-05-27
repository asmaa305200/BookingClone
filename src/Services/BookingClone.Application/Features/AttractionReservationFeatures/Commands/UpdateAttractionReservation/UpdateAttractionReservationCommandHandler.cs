using AutoMapper;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.UpdateAttractionReservation;

internal sealed class UpdateAttractionReservationCommandHandler : IRequestHandler<UpdateAttractionReservationCommand, GetAttractionReservationDto?>
{
    private readonly IAttractionReservationRepository _attractionReservationRepository;
    private readonly IMapper _mapper;

    public UpdateAttractionReservationCommandHandler(IAttractionReservationRepository repository, IMapper mapper)
    {
        _attractionReservationRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionReservationDto?> Handle(UpdateAttractionReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _attractionReservationRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (reservation is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, reservation);
        _attractionReservationRepository.Update(reservation);
        await _attractionReservationRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetAttractionReservationDto>(reservation);
    }
}
