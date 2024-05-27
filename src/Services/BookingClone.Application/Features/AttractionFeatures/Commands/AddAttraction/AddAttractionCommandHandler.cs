using AutoMapper;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.AddAttraction;

internal sealed class AddAttractionCommandHandler : IRequestHandler<AddAttractionCommand, GetAttractionDto>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IMapper _mapper;

    public AddAttractionCommandHandler(IAttractionRepository repository, IMapper mapper)
    {
        _attractionRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionDto> Handle(AddAttractionCommand request, CancellationToken cancellationToken)
    {
        var newAttraction = _mapper.Map<Attraction>(request.Dto);

        _attractionRepository.Add(newAttraction);
        await _attractionRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetAttractionDto>(newAttraction);
    }
}
