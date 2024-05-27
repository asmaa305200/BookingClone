using AutoMapper;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Queries.GetAttractionById;

internal sealed class GetAttractionByIdQueryHandler : IRequestHandler<GetAttractionByIdQuery, GetAttractionDto?>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IMapper _mapper;

    public GetAttractionByIdQueryHandler(IAttractionRepository repository, IMapper mapper)
    {
        _attractionRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionDto?> Handle(GetAttractionByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _attractionRepository.GetAttractionDetails(request.ID, cancellationToken);
        return result is null ? null : _mapper.Map<GetAttractionDto>(result);
    }
}
