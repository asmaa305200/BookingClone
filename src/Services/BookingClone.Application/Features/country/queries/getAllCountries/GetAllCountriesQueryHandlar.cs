using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingClone.Application.Features.country.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.country.queries.GitAllCountries;
public class GetAllCountriesQueryHandlar : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryMinimalDto>>
{
    private readonly ICountryRepository _countryRepository;

    public GetAllCountriesQueryHandlar(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;

    }


    
    public async Task<IEnumerable<CountryMinimalDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var Country = _countryRepository.GetAll().Result;
        var CountryDto = Country.Select(a => new CountryMinimalDto { Name = a.Name });
        return (CountryDto);
    }
}
