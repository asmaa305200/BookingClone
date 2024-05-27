using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.DTOs;

using MediatR;

namespace BookingClone.Application.Features.city.queries.GetCityById;
public class GetCityByIdQuery : IRequest<CityDetailsDto>
{
    
    public  int ID { get; set; }

    public GetCityByIdQuery(int iD)
    {
        ID = iD;
    }

}
