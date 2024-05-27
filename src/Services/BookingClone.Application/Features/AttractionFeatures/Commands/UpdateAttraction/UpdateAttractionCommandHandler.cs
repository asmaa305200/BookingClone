using AutoMapper;
using BookingClone.Application.Features.AttractionFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.UpdateAttraction;

internal sealed class UpdateAttractionCommandHandler : IRequestHandler<UpdateAttractionCommand, GetAttractionDto?>
{
    private readonly IAttractionRepository _attractionRepository;
    private readonly IMapper _mapper;

    public UpdateAttractionCommandHandler(IAttractionRepository repository, IMapper mapper)
    {
        _attractionRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionDto?> Handle(UpdateAttractionCommand request, CancellationToken cancellationToken)
    {
        var existingAttraction = await _attractionRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (existingAttraction is null) 
        {
            return null;
        }

        _mapper.Map(request.Dto, existingAttraction);
        _attractionRepository.Update(existingAttraction);
        await _attractionRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetAttractionDto>(existingAttraction);
    }
}
