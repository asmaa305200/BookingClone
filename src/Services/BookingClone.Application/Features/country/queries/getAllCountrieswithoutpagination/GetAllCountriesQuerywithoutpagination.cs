using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BookingClone.Application.Features.country.DTOs;

using MediatR;

namespace BookingClone.Application.Features.country.queries.GitAllCountries;
public class GetAllCountriesQuerywithoutpagination : IRequest<IEnumerable<CountryDetailsDto>>
{

    public string? Name { get; set; }
    public int? ID { get; set; }

}
