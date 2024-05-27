using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Domain.Contracts;


using MediatR;

namespace BookingClone.Application.Features.continent.queries.getAllContinentswithoutpagination;
public class getAllContinentswithoutpaginationQueryHandlar : IRequestHandler<GetAllContinentsQuerywithoutpagination, IEnumerable<ContinentDetailsDto>>
{
    private readonly IContinentRepository _continentRepository;

    public getAllContinentswithoutpaginationQueryHandlar(IContinentRepository continentRepository)
    {
        _continentRepository = continentRepository;

    }

    public  async Task<IEnumerable<ContinentDetailsDto>> Handle(GetAllContinentsQuerywithoutpagination request, CancellationToken cancellationToken)
    {
        var Continent = _continentRepository.GetAll().Result;
        var ContinentDto = Continent.Select(a => new ContinentDetailsDto { Name = a.Name, ID = a.ID });
        return (ContinentDto);
    }

   
}
