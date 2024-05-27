using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace BookingClone.Application.Features.continent.commands.DeleteContinent;
public class DeleteContinentCommmand : IRequest<int>
{
    

    public int ID { set; get; }

    public DeleteContinentCommmand(int iD)
    {
        ID = iD;
    }

}
