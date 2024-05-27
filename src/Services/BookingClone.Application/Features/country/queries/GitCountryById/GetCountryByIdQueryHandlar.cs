using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;


using BookingClone.Application.Features.country.DTOs;
using BookingClone.Domain.Contracts;


using MediatR;

namespace BookingClone.Application.Features.country.queries.GitCountryById;
public class GetCountryByIdQueryHandlar : IRequestHandler<GetCountryByIdQuery, CountryDetailsDto?>
{

    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountryByIdQueryHandlar(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryDetailsDto?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _countryRepository.GetByIdAsync(request.ID, cancellationToken);
        return result is null ? null : _mapper.Map<CountryDetailsDto>(result);
    }

  

        //private readonly ICountryRepository _countryRepository;

        //public GetCountryByIdQueryHandlar(ICountryRepository countryRepository)
        //{
        //    _countryRepository = countryRepository;

        //}



        //public async Task<CountryDetailsDto?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        //{

        //    var country = await _countryRepository.GetByIdAsync(request.ID);

        //    return new CountryDetailsDto()
        //    {
        //        Name = country.Name,

        //    };

        //}
    
}
