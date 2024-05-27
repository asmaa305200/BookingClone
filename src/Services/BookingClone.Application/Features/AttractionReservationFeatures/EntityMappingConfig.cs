using AutoMapper;
using BookingClone.Application.Features.AttractionReservationFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.AttractionReservationFeatures;

internal sealed class EntityMappingConfig : Profile
{
    public EntityMappingConfig()
    {
        CreateMap<AttractionReservation, GetAttractionReservationDto>();
        CreateMap<AddAttractionReservationDto, AttractionReservation>();
        CreateMap<UpdateAttractionReservationDto, AttractionReservation>();
        CreateMap<PagedList<AttractionReservation>, PagedList<GetAttractionReservationDto>>()
            .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));

        CreateMap<ReservedAttraction, GetReservedAttractionDto>();
    }
}
