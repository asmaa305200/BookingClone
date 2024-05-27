using AutoMapper;
using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Queries.GetAllHotelReviews;

public class GetAllHotelReviewsQueryHandler : IRequestHandler<GetAllHotelReviewsQuery, PagedList<GetHotelReviewDto>>
{
    private readonly IHotelReviewRepository _hotelReviewRepository;
    private readonly IMapper _mapper;

    public GetAllHotelReviewsQueryHandler(IHotelReviewRepository hotelReviewRepository, IMapper mapper)
    {
        _hotelReviewRepository = hotelReviewRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<GetHotelReviewDto>> Handle(GetAllHotelReviewsQuery request, CancellationToken cancellationToken)
    {
        var hotelReview = await _hotelReviewRepository.GetPaginatedList(request.Query, cancellationToken);
        return _mapper.Map<PagedList<GetHotelReviewDto>>(hotelReview);
    }
}
