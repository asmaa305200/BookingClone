using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using BookingClone.Application.Features.city.DTOs;
using BookingClone.Application.Features.city.queries.GetAllCities;
using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Domain.Common;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.continent.queries.GetAllcontinent;
internal class getallcontinentqueryhandler2 : IRequestHandler<getallcontinentquery2, PagedList<ContinentDetailsDto>>
{

    private readonly IContinentRepository _continentRepository;
    private readonly IMapper _mapper;
    public getallcontinentqueryhandler2(IContinentRepository continentRepository, IMapper mapper)
    {
        _continentRepository = continentRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<ContinentDetailsDto>> Handle(getallcontinentquery2 request, CancellationToken cancellationToken)
    {
        var reservations = await _continentRepository.GetPaginatedList(request.Query, cancellationToken);
        return _mapper.Map<PagedList<ContinentDetailsDto>>(reservations);
    }
    
}
