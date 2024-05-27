using AutoMapper;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Queries.GetPaginatedAttractions;

internal sealed class GetPaginatedAttractionsQueryHandler : IRequestHandler<GetPaginatedAttractionsQuery, PagedList<GetAttractionDto>>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IMapper _mapper;

    public GetPaginatedAttractionsQueryHandler(IAttractionRepository attractionRepository, IMapper mapper)
    {
        _attractionRepository = attractionRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<GetAttractionDto>> Handle(GetPaginatedAttractionsQuery request, CancellationToken cancellationToken)
    {
        var attractions = await _attractionRepository.GetPaginatedList(request.Query, cancellationToken);
        return _mapper.Map<PagedList<GetAttractionDto>>(attractions);
    }
}
