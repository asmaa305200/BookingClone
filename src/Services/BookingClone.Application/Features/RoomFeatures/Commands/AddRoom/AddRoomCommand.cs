using BookingClone.Application.Features.RoomFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Commands.AddRoom;

public sealed class AddRoomCommand : IRequest<GetRoomDto>
{
    public required AddRoomDto Dto { get; set; }
}
