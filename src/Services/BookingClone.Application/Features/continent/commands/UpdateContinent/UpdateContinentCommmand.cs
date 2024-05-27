using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BookingClone.Application.Features.continent.DTOs;

using MediatR;

namespace BookingClone.Application.Features.continent.commands.UpdateContinent;
public class UpdateContinentCommmand : IRequest<ContinentDetailsDto>
{
    
        public int ID { get; set; }
        public string? Name { get; set; }


    

}
