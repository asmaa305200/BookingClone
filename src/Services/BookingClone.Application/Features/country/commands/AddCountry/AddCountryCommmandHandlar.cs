using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.commands.AddCity;
using BookingClone.Application.Features.city.DTOs;
using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Application.Features.country.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.country.commands.AddCountry;
public class AddCountryCommmandHandlar : IRequestHandler<AddCountryCommmand, CountryDetailsDto>
{
    private readonly ICountryRepository _countryRepository;

    public AddCountryCommmandHandlar(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;

    }

    public async Task<CountryDetailsDto> Handle(AddCountryCommmand request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            Name = request.Name,
            ContinentID = request.ContinentID,


        };



        country =  _countryRepository.Add(country);

        _countryRepository.SaveAsync(cancellationToken);

        return new CountryDetailsDto()
        {
            Name = country.Name,
            //ContinentID = country.ContinentID,


        };


       
    }


  

}
