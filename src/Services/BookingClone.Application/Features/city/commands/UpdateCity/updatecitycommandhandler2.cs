using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.city.commands.UpdateCity;
internal class updatecitycommandhandler2 : IRequestHandler<updatecitycommand2, CityDetailsDto?>
{

    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public updatecitycommandhandler2(ICityRepository repository, IMapper mapper)
    {
        _cityRepository = repository;
        _mapper = mapper;
    }

    public async Task<CityDetailsDto?> Handle(updatecitycommand2 request, CancellationToken cancellationToken)
    {
        var reservation = await _cityRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (reservation is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, reservation);
        _cityRepository.Update(reservation);
        await _cityRepository.SaveAsync(cancellationToken);

        return _mapper.Map<CityDetailsDto>(reservation);
    }

    

}
