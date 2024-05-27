using AutoMapper;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Commands.AddAttractionReservation;

internal sealed class AddAttractionReservationCommandHandler : IRequestHandler<AddAttractionReservationCommand, GetAttractionReservationDto>
{
    private readonly IAttractionReservationRepository _attractionReservationRepository;
    private readonly IMapper _mapper;

    public AddAttractionReservationCommandHandler(IAttractionReservationRepository repository, IMapper mapper)
    {
        _attractionReservationRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionReservationDto> Handle(AddAttractionReservationCommand request, CancellationToken cancellationToken)
    {
        var newReservation = _mapper.Map<AttractionReservation>(request.Dto);
        newReservation.Status = Domain.Enums.ReservationStatus.Pending;

        _attractionReservationRepository.Add(newReservation);
        await _attractionReservationRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetAttractionReservationDto>(newReservation);
    }
}
