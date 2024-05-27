using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.continent.commands.DeleteContinent;
public class DeleteContinentCommmandHandlar : IRequestHandler<DeleteContinentCommmand, int>
{
    private readonly IContinentRepository _continentRepository;

    public DeleteContinentCommmandHandlar(IContinentRepository continentRepository)
    {
        _continentRepository = continentRepository;
    }
    

       

    public async Task<int> Handle(DeleteContinentCommmand request, CancellationToken cancellationToken)
    {
        return await _continentRepository.DeleteAsync(request.ID, cancellationToken);

    }

}
