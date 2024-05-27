using AutoMapper;
using BookingClone.Application.Features.RoomFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Commands.UpdateRoom;

public sealed class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, GetRoomDto>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public UpdateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<GetRoomDto> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (room is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, room);
        _roomRepository.Update(room);
        await _roomRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetRoomDto>(room);
    }
}
