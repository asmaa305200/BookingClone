using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Application.Features.continent.DTOs;

using MediatR;

namespace BookingClone.Application.Features.continent.commands.AddContinent;
public class addcontinentcommand2 : IRequest<ContinentDetailsDto>
{
    public required ContinentDetailsDto Dto { get; set; }
    

}
