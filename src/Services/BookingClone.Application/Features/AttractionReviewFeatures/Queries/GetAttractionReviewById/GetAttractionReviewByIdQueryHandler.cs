using AutoMapper;
using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAttractionReviewById;

internal sealed class GetAttractionReviewByIdQueryHandler : IRequestHandler<GetAttractionReviewByIdQuery, GetAttractionReviewDto?>
{
    private readonly IAttractionReviewRepository _attractionReviewRepository;
    private readonly IMapper _mapper;

    public GetAttractionReviewByIdQueryHandler(IAttractionReviewRepository repository, IMapper mapper)
    {
        _attractionReviewRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionReviewDto?> Handle(GetAttractionReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var AttractionReview = await _attractionReviewRepository.GetByIdAsync(request.ID, cancellationToken);

        if (AttractionReview is null)
        {
            return null;
        }

        GetAttractionReviewDto result = _mapper.Map<GetAttractionReviewDto>(AttractionReview);
        return result;
    }
}

