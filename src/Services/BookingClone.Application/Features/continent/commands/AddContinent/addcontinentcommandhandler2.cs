using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingClone.Application.Features.continent.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;

using MediatR;

namespace BookingClone.Application.Features.continent.commands.AddContinent;
public class addcontinentcommandhandler2 : IRequestHandler<addcontinentcommand2, ContinentDetailsDto>
{

    private readonly IContinentRepository _continentRepository;
    private readonly IMapper _mapper;
    public addcontinentcommandhandler2(IContinentRepository continentRepository, IMapper mapper)
    {
        _continentRepository = continentRepository;
        _mapper = mapper;
    }

    public async Task<ContinentDetailsDto> Handle(addcontinentcommand2 request, CancellationToken cancellationToken)
    {
        var newContinent = _mapper.Map<Continent>(request.Dto);
        _continentRepository.Add(newContinent);
        await _continentRepository.SaveAsync(cancellationToken);

        return _mapper.Map<ContinentDetailsDto>(newContinent);
    }





  




    }
