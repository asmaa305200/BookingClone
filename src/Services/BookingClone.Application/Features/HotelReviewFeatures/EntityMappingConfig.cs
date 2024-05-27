using AutoMapper;

using BookingClone.Application.Features.HotelReviewFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.HotelReviewFeatures;

public class EntityMappingConfig : Profile
{
    public EntityMappingConfig()
    {
        CreateMap<HotelReview, GetHotelReviewDto>();
        CreateMap<AddHotelReviewDto, HotelReview>();
        CreateMap<UpdateHotelReviewDto, HotelReview>();
        CreateMap<PagedList<HotelReview>, PagedList<GetHotelReviewDto>>()
            .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));
    }
}
