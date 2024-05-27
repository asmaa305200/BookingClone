using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Application.Features.city.queries.GetCityById;
using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.continent.queries.GetContinentById;
public class GetContinentByIdQueryHandlar : IRequestHandler<GetContinentByIdQuery, ContinentDetailsDto?>
{

    private readonly IContinentRepository _continentRepository;
    private readonly IMapper _mapper;
    public GetContinentByIdQueryHandlar(IContinentRepository continentRepository, IMapper mapper)
    {
        _continentRepository = continentRepository;
        _mapper = mapper;
    }

    public async Task<ContinentDetailsDto?> Handle(GetContinentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _continentRepository.GetByIdAsync(request.ID, cancellationToken);
        return result is null ? null : _mapper.Map<ContinentDetailsDto>(result);
    }


}
