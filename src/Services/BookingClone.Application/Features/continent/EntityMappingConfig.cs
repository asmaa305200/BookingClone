using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.continent;
internal class EntityMappingConfig : Profile
{

    public EntityMappingConfig()
    {
        CreateMap<Continent, ContinentDetailsDto>().ReverseMap();
        CreateMap<Continent, ContinentMinimalDto>().ReverseMap();

        CreateMap<PagedList<Continent>, PagedList<ContinentDetailsDto>>()
           .ForMember(x => x.Data, f => f.MapFrom(x => x.Data));




    }


}
