using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using BookingClone.Application.Features.country.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;

namespace BookingClone.Application.Features.country.commands.AddCountry;
public class addcountycommandhandler2 : IRequestHandler<addcountrycommand2, CountryDetailsDto>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public addcountycommandhandler2(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryDetailsDto> Handle(addcountrycommand2 request, CancellationToken cancellationToken)
    {
        var newCounrty = _mapper.Map<Country>(request.Dto);
        _countryRepository.Add(newCounrty);
        await _countryRepository.SaveAsync(cancellationToken);

        return _mapper.Map<CountryDetailsDto>(newCounrty);
    }







}
