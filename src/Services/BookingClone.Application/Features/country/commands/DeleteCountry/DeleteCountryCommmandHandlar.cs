using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.commands.DeleteCity;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.country.commands.DeleteCountry;
public class DeleteCountryCommmandHandlar : IRequestHandler<DeleteCountryCommmand, int>
{

    private readonly ICountryRepository _countryRepository;
    public DeleteCountryCommmandHandlar(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<int> Handle(DeleteCountryCommmand request, CancellationToken cancellationToken)
    {
        return await _countryRepository.DeleteAsync(request.ID, cancellationToken);
    }

    
}
