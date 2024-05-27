using AutoMapper;
using BookingClone.Application.Features.RoomFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Queries.GetRoomById;

public sealed class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, GetRoomDto>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<GetRoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _roomRepository.GetRoomDetails(request.ID, cancellationToken);
        return result is null ? null : _mapper.Map<GetRoomDto>(result);
    }
}
