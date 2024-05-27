using AutoMapper;
using BookingClone.Application.Features.HotelFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.HotelFeatures;

public class EntityMappingConfig : Profile
{
    public EntityMappingConfig()
    {
        CreateMap<Hotel, GetHotelsDto>();
        CreateMap<AddHotelDto, Hotel>();
        CreateMap<UpdateHotelDto, Hotel>();
        CreateMap<PagedList<Hotel>, PagedList<GetHotelsDto>>()
            .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));
    }
}
