using AutoMapper;
using BookingClone.Application.Features.RoomFeatures.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Commands.AddRoom;

public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, GetRoomDto>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public AddRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<GetRoomDto> Handle(AddRoomCommand request, CancellationToken cancellationToken)
    {
        var newRoom = _mapper.Map<Room>(request.Dto);
        _roomRepository.Add(newRoom);
        await _roomRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetRoomDto>(newRoom);
    }
}
