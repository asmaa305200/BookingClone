using AutoMapper;
using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.AttractionReviewFeatures.Commands.UpdateAttractionReview;

internal sealed class UpdateAttractionReviewCommandHandler : IRequestHandler<UpdateAttractionReviewCommand, GetAttractionReviewDto?>
{
    private readonly IAttractionReviewRepository _AttractionReviewRepository;
    private readonly IMapper _mapper;

    public UpdateAttractionReviewCommandHandler(IAttractionReviewRepository repository, IMapper mapper)
    {
        _AttractionReviewRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetAttractionReviewDto?> Handle(UpdateAttractionReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _AttractionReviewRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (review is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, review);
        _AttractionReviewRepository.Update(review);
        await _AttractionReviewRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetAttractionReviewDto>(review);
    }
}
