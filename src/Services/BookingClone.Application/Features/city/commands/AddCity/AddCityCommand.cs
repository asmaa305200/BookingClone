using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.city.DTOs;
using BookingClone.Domain.Entities;

using MediatR;

namespace BookingClone.Application.Features.city.commands.AddCity;
public class AddCityCommand : IRequest<CityDetailsDto>
{
    

    public string Name { get; set; }
    public int? CountryID { get; set; }

    public AddCityCommand(string name)
    {
        Name = name;

    }


}
