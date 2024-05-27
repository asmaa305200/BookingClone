using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;

using MediatR;

namespace BookingClone.Application.Features.city.commands.UpdateCity;
public class UpdateCityCommandHandlar : IRequestHandler<UpdateCityCommand, CityDetailsDto>
{

    private readonly ICityRepository _cityRepository;


    public UpdateCityCommandHandlar(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CityDetailsDto> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.ID);
        var cityy = new CityDetailsDto
        {
           Name = request.Name,
           CountryID=request.CountryID

        };
        city.Name = request.Name;
       
       
          _cityRepository.Update(city);
        _cityRepository.SaveAsync(cancellationToken);

        return cityy;
    }

    
}
