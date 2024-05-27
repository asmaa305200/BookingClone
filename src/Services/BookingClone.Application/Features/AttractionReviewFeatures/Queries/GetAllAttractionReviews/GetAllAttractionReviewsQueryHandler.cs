using AutoMapper;
using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Queries.GetAllAttractionReviews;

public class GetAllAttractionReviewsQueryHandler : IRequestHandler<GetAllAttractionReviewsQuery, PagedList<GetAttractionReviewDto>>
{
    private readonly IAttractionReviewRepository _attractionReviewRepository;
    private readonly IMapper _mapper;

    public GetAllAttractionReviewsQueryHandler(IAttractionReviewRepository attractionReviewRepository, IMapper mapper)
    {
        _attractionReviewRepository = attractionReviewRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<GetAttractionReviewDto>> Handle(GetAllAttractionReviewsQuery request, CancellationToken cancellationToken)
    {
        var attractionReview = await _attractionReviewRepository.GetPaginatedList(request.Query, cancellationToken);
        return _mapper.Map<PagedList<GetAttractionReviewDto>>(attractionReview);
    }
}
