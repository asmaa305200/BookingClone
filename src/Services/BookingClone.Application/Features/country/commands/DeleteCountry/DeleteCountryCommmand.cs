using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace BookingClone.Application.Features.country.commands.DeleteCountry;
public class DeleteCountryCommmand : IRequest<int>
{
   

    public int ID { set; get; }
    public DeleteCountryCommmand(int iD)
    {
        ID = iD;
    }

}
