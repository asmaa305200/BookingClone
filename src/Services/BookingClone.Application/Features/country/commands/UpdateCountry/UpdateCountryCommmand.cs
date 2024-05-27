using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BookingClone.Application.Features.country.DTOs;

using MediatR;

namespace BookingClone.Application.Features.country.commands.UpdateCountry;
public class UpdateCountryCommmand : IRequest<CountryDetailsDto>
{
    
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? ContinentID { get; set; }






}
