using AutoMapper;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.AddRoomReservation;

internal sealed class AddRoomReservationCommandHandler : IRequestHandler<AddRoomReservationCommand, GetRoomReservationDto>
{
    private readonly IRoomReservationRepository _RoomReservationRepository;
    private readonly IMapper _mapper;

    public AddRoomReservationCommandHandler(IRoomReservationRepository repository, IMapper mapper)
    {
        _RoomReservationRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetRoomReservationDto> Handle(AddRoomReservationCommand request, CancellationToken cancellationToken)
    {
        var newReservation = _mapper.Map<RoomReservation>(request.Dto);
        newReservation.Status = Domain.Enums.ReservationStatus.Pending;

        _RoomReservationRepository.Add(newReservation);
        await _RoomReservationRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetRoomReservationDto>(newReservation);
    }
}
