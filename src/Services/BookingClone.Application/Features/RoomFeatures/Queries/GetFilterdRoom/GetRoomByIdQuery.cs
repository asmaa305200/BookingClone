using BookingClone.Application.Features.RoomFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Queries.GetRoomById;

public sealed class GetFilterdRoomQuery : IRequest<List<GetRoomDto>>
{
    public decimal from { get; set; }
    public bool ava { get; set; }
    public decimal to { get; set; }     
}
