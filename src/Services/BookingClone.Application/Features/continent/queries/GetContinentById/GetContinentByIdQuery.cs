using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Application.Features.continent.DTOs;

using MediatR;

namespace BookingClone.Application.Features.continent.queries.GetContinentById;
public class GetContinentByIdQuery : IRequest<ContinentDetailsDto>
{
    public  int ID { get; set; }

    public GetContinentByIdQuery(int iD)
    {
        ID = iD;
    }

}
