using AutoMapper;
using BookingClone.Application.Features.RoomReservationFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.RoomReservationFeatures.Commands.UpdateRoomReservation;

internal sealed class UpdateRoomReservationCommandHandler : IRequestHandler<UpdateRoomReservationCommand, GetRoomReservationDto?>
{
    private readonly IRoomReservationRepository _RoomReservationRepository;
    private readonly IMapper _mapper;

    public UpdateRoomReservationCommandHandler(IRoomReservationRepository repository, IMapper mapper)
    {
        _RoomReservationRepository = repository;
        _mapper = mapper;
    }

    public async Task<GetRoomReservationDto?> Handle(UpdateRoomReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _RoomReservationRepository.GetByIdAsync(request.Dto.ID, cancellationToken);

        if (reservation is null)
        {
            return null!;
        }

        _mapper.Map(request.Dto, reservation);
        _RoomReservationRepository.Update(reservation);
        await _RoomReservationRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetRoomReservationDto>(reservation);
    }
}
