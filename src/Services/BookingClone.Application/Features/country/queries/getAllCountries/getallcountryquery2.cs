using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.country.DTOs;
using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.country.queries.GitAllCountries;
public class getallcountryquery2 : IRequest<PagedList<CountryDetailsDto>>
{
    public required PaginationQuery Query { get; set; }

    
}
