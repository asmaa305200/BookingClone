using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BookingClone.Application.Features.country.DTOs;

using MediatR;

namespace BookingClone.Application.Features.country.commands.AddCountry;
public class addcountrycommand2 : IRequest<CountryDetailsDto>
{
    public required CountryDetailsDto Dto { get; set; }
    
}
