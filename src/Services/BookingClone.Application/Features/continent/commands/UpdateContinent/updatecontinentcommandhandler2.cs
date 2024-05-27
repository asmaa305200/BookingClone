using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Repositories;

using MediatR;

namespace BookingClone.Application.Features.continent.commands.UpdateContinent;
internal class updatecontinentcommandhandler2 : IRequestHandler<updatecontinentcommand2, ContinentDetailsDto?>
{
    private readonly IContinentRepository _continentRepository;
    private readonly IMapper _mapper;
    public updatecontinentcommandhandler2(IContinentRepository continentRepository, IMapper mapper)
    {
        _continentRepository = continentRepository;
        _mapper = mapper;
    }

    public async Task<ContinentDetailsDto?> Handle(updatecontinentcommand2 request, CancellationToken cancellationToken)
    {
        var reservation = await _continentRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (reservation is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, reservation);
        _continentRepository.Update(reservation);
        await _continentRepository.SaveAsync(cancellationToken);

        return _mapper.Map<ContinentDetailsDto>(reservation);
    }


    

}
