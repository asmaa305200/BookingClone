using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Application.Features.country.DTOs;
using MediatR;

namespace BookingClone.Application.Features.continent.queries.getAllContinentswithoutpagination;
public class GetAllContinentsQuerywithoutpagination : IRequest<IEnumerable<ContinentDetailsDto>>
{

    public string? Name { get; set; }
    public int? ID { get; set; }
   
}
