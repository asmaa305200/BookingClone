using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.country.DTOs;
using BookingClone.Domain.Contracts;


using MediatR;

namespace BookingClone.Application.Features.country.commands.UpdateCountry;
public class UpdateCountryCommmandHandler : IRequestHandler<UpdateCountryCommmand, CountryDetailsDto>
{
    private readonly ICountryRepository _countryRepository;

    public UpdateCountryCommmandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;

    }

   

    public async Task<CountryDetailsDto> Handle(UpdateCountryCommmand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.ID);

        

        var con =new CountryDetailsDto {
            Name = request.Name,
           ContinentID =request.ContinentID
        };

        country.Name = request.Name;

        _countryRepository.Update(country);
        _countryRepository.SaveAsync(cancellationToken);

        return con;

       




    }
}
