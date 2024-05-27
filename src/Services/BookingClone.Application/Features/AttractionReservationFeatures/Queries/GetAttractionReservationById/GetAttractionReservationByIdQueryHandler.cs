using AutoMapper;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetAttractionReservationById;

internal sealed class GetAttractionReservationByIdQueryHandler : IRequestHandler<GetAttractionReservationByIdQuery, GetAttractionReservationDto?>
{
    private readonly IAttractionReservationRepository _attractionReservationRepository;
    private readonly IMapper _mapper;

    public GetAttractionReservationByIdQueryHandler(IAttractionReservationRepository repository, IMapper mapper)
    {
        _attractionReservationRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionReservationDto?> Handle(GetAttractionReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var attractionReservation = await _attractionReservationRepository.GetByIdAsync(request.ID, cancellationToken);

        if (attractionReservation is null)
        {
            return null;
        }

        GetAttractionReservationDto result = _mapper.Map<GetAttractionReservationDto>(attractionReservation);
        return result;
    }
}
