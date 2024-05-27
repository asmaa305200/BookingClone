using AutoMapper;
using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Queries.GetHotelReviewById
{
    internal class GetHotelReviewByIdQueryHandler : IRequestHandler<GetHotelReviewByIdQuery, GetHotelReviewDto?>
    {
        private readonly IHotelReviewRepository _hotelReviewRepository;
        private readonly IMapper _mapper;

        public GetHotelReviewByIdQueryHandler(IHotelReviewRepository repository, IMapper mapper)
        {
            _hotelReviewRepository = repository;
            _mapper = mapper;
        }

        public async Task<GetHotelReviewDto?> Handle(GetHotelReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var HotelReview = await _hotelReviewRepository.GetByIdAsync(request.ID, cancellationToken);

            if (HotelReview is null)
            {
                return null;
            }

            GetHotelReviewDto result = _mapper.Map<GetHotelReviewDto>(HotelReview);
            return result;
        }
    }
}

