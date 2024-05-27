using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Application.Features.RoomFeatures.DTOs;

using BookingClone.Domain.Common;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Queries.GetAllRooms;
public class GetAllRoomsQuery: IRequest<PagedList<GetRoomDto>>
{
    public required PaginationQuery Query { get; set; }

    //public decimal? Price { get; set; }
}
