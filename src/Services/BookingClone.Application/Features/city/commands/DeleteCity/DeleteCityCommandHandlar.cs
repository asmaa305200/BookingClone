using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.AttractionReservationFeatures.Commands.DeleteAttractionReservation;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.city.commands.DeleteCity;
public class DeleteCityCommandHandlar : IRequestHandler<DeleteCityCommand, int>
{
    private readonly ICityRepository _cityRepository;
    public DeleteCityCommandHandlar(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        return await _cityRepository.DeleteAsync(request.ID, cancellationToken);
    }

    
}
