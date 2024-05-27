using AutoMapper;
using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.AddAttractionReview;

public class AddAttractionReviewCommandHandler : IRequestHandler<AddAttractionReviewCommand, GetAttractionReviewDto>
{
    private readonly IAttractionReviewRepository _AttractionReviewRepository;
    private readonly IMapper _mapper;

    public AddAttractionReviewCommandHandler(IAttractionReviewRepository repository, IMapper mapper)
    {
        _AttractionReviewRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionReviewDto> Handle(AddAttractionReviewCommand request, CancellationToken cancellationToken)
    {
        var newReview = _mapper.Map<AttractionReview>(request.Dto);

        _AttractionReviewRepository.Add(newReview);
        await _AttractionReviewRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetAttractionReviewDto>(newReview);
    }
}


