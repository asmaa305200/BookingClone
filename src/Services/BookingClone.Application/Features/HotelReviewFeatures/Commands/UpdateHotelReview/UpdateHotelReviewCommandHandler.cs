using AutoMapper;
using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelReviewFeatures.Commands.UpdateHotelReview;

internal sealed class UpdateHotelReviewCommandHandler : IRequestHandler<UpdateHotelReviewCommand, GetHotelReviewDto?>
    {
    private readonly IHotelReviewRepository _HotelReviewRepository;
    private readonly IMapper _mapper;

    public UpdateHotelReviewCommandHandler(IHotelReviewRepository repository, IMapper mapper)
    {
        _HotelReviewRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetHotelReviewDto?> Handle(UpdateHotelReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _HotelReviewRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (review is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, review);
        _HotelReviewRepository.Update(review);
        await _HotelReviewRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetHotelReviewDto>(review);
    }
}
