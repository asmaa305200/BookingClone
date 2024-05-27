using AutoMapper;
using BookingClone.Application.Features.RoomFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomFeatures.Queries.GetRoomById;

public sealed class GetFilterdRoomQueryHandler : IRequestHandler<GetFilterdRoomQuery, List<GetRoomDto>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetFilterdRoomQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<List<GetRoomDto>> Handle(GetFilterdRoomQuery request, CancellationToken cancellationToken)
    {
        var result =  _roomRepository.GetAll().Result
            .Where(x => x.Price >= request.from && x.Price <= request.to && x.IsAvailable == request.ava).ToList();//.GetRoomDetails(request.ID, cancellationToken);
        return result is null ? null : _mapper.Map<List<GetRoomDto>>(result);
    }
}
