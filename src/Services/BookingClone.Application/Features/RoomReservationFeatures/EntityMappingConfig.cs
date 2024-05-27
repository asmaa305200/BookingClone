using AutoMapper;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.RoomReservationFeatures;

internal sealed class EntityMappingConfig : Profile
{
    public EntityMappingConfig()
    {
        CreateMap<RoomReservation, GetRoomReservationDto>();
        CreateMap<AddRoomReservationDto, RoomReservation>();
        CreateMap<UpdateRoomReservationDto, RoomReservation>();
        CreateMap<PagedList<RoomReservation>, PagedList<GetRoomReservationDto>>()
            .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));
    }
}
