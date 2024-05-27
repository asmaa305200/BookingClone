using AutoMapper;

using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;


namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.AddHotelReview;

    public class AddHotelReviewCommandHandler : IRequestHandler<AddHotelReviewCommand,GetHotelReviewDto>
    {
    private readonly IHotelReviewRepository _HotelReviewRepository;
    private readonly IMapper _mapper;

    public AddHotelReviewCommandHandler(IHotelReviewRepository repository, IMapper mapper)
    {
        _HotelReviewRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetHotelReviewDto> Handle(AddHotelReviewCommand request, CancellationToken cancellationToken)
    {
        var newReview = _mapper.Map<HotelReview>(request.Dto);
        

        _HotelReviewRepository.Add(newReview);
        await _HotelReviewRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetHotelReviewDto>(newReview);
    }
}


