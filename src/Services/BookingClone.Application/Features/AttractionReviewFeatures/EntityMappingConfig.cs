using AutoMapper;

using BookingClone.Application.Features.AttractionReviewFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.AttractionReviewFeatures;

public class EntityMappingConfig : Profile
{
    public EntityMappingConfig()
    {
        CreateMap<AttractionReview, GetAttractionReviewDto>();
        CreateMap<AddAttractionReviewDto, AttractionReview>();
        CreateMap<UpdateAttractionReviewDto, AttractionReview>();
        CreateMap<PagedList<AttractionReview>, PagedList<GetAttractionReviewDto>>()
            .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));
    }
}
