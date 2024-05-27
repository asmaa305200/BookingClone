using BookingClone.Application.Features.RoomFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Commands.UpdateRoom;

public sealed class UpdateRoomCommand : IRequest<GetRoomDto>
{
    public required UpdateRoomDto Dto { get; set; }
}
