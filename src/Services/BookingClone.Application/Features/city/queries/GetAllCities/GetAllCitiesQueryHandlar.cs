using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Domain.Contracts;

using MediatR;

namespace BookingClone.Application.Features.city.queries.GetAllCities;
public class GetAllCitiesQueryHandlar : IRequestHandler<GetAllCitiesQuery, IEnumerable<CityMinimalDto>>
{

        private readonly ICityRepository _cityRepository;

        public GetAllCitiesQueryHandlar(ICityRepository cityRepository)
        {
           _cityRepository = cityRepository;

        }

    public async Task<IEnumerable<CityMinimalDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        var city =  _cityRepository.GetAll().Result;
        var city_Dto = city.Select(a => new CityMinimalDto { Name = a.Name }); 
        return (city_Dto);
         
    }



   
}
