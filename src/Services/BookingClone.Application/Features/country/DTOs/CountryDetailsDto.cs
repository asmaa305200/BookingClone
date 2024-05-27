using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.country.DTOs;
public class CountryDetailsDto
{

    public int ID { get; set; }
    public int? ContinentID { get; set; }
    public string Name { get; set; }

    

  
}
