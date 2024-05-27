using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.city.commands.AddCity;
public class addcitycommandhandler2 : IRequestHandler<addcitycommand2, CityDetailsDto>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public addcitycommandhandler2(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityDetailsDto> Handle(addcitycommand2 request, CancellationToken cancellationToken)
    {
        var newCity = _mapper.Map<City>(request.Dto);
        _cityRepository.Add(newCity);
        await _cityRepository.SaveAsync(cancellationToken);

        return _mapper.Map<CityDetailsDto>(newCity);
    }

}
