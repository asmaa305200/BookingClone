using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace BookingClone.Application.Features.city.commands.DeleteCity;
public class DeleteCityCommand : IRequest<int>
{
    
    public int ID {set; get;}

    public DeleteCityCommand(int iD)
    {
        ID = iD;
    }

}
