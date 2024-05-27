using AutoMapper;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReservationFeatures.Queries.GetReservedAttractionDetailsById;

internal sealed class GetReservedAttractionDetailsByIdQueryHandler : IRequestHandler<GetReservedAttractionDetailsByIdQuery, GetReservedAttractionDto>
{
    private readonly IAttractionReservationRepository _attractionRepository;
    private readonly IMapper _mapper;

    public GetReservedAttractionDetailsByIdQueryHandler(IAttractionReservationRepository attractionRepository, IMapper mapper)
    {
        _attractionRepository = attractionRepository;
        _mapper = mapper;
    }

    public async Task<GetReservedAttractionDto> Handle(GetReservedAttractionDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var details = await _attractionRepository.GetReservationDetails(request.ReservationId, request.AttractionId, cancellationToken);
        return _mapper.Map<GetReservedAttractionDto>(details);
    }
}
