using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingClone.Application.Features.city.DTOs;
using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.city.queries.GetAllCities;
public class getallcitiesquery2 : IRequest<PagedList<CityDetailsDto>>
{
    public required PaginationQuery Query { get; set; }
    
}
