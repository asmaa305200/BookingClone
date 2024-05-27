using AutoMapper;
using BookingClone.Application.Features.RoomFeatures.DTOs;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.RoomFeatures;

public class EntityMappingConfig : Profile
{
    public EntityMappingConfig()
    {
        CreateMap<Room, GetRoomDto>();
        CreateMap<AddRoomDto, Room>();
        CreateMap<UpdateRoomDto, Room>();
        CreateMap<PagedList<Room>, PagedList<GetRoomDto>>()
           .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));


    }
}
