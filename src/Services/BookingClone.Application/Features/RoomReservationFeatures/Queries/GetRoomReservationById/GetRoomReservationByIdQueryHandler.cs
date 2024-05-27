using AutoMapper;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Queries.GetRoomReservationById;

internal sealed class GetRoomReservationByIdQueryHandler : IRequestHandler<GetRoomReservationByIdQuery, GetRoomReservationDto?>
{
    private readonly IRoomReservationRepository _RoomReservationRepository;
    private readonly IMapper _mapper;

    public GetRoomReservationByIdQueryHandler(IRoomReservationRepository repository, IMapper mapper)
    {
        _RoomReservationRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetRoomReservationDto?> Handle(GetRoomReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var RoomReservation = await _RoomReservationRepository.GetByIdAsync(request.ID, cancellationToken);

        if (RoomReservation is null)
        {
            return null;
        }

        GetRoomReservationDto result = _mapper.Map<GetRoomReservationDto>(RoomReservation);
        return result;
    }
}
