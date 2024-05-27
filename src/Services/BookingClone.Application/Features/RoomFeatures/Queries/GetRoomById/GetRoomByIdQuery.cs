using BookingClone.Application.Features.RoomFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Queries.GetRoomById;

public sealed class GetRoomByIdQuery : IRequest<GetRoomDto>
{
    public int ID { get; set; }
}
