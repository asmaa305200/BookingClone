using AutoMapper;
using BookingClone.Application.Features.HotelFeatures.DTOs;
using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.UpdateHotel;

public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, GetHotelsDto>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public UpdateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<GetHotelsDto> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var existingAttraction = await _hotelRepository.GetByIdAsync(request.Dto.Id, cancellationToken);

        if (existingAttraction is null)
        {
            return null;
        }

        _mapper.Map(request.Dto, existingAttraction);
        _hotelRepository.Update(existingAttraction);
        await _hotelRepository.SaveAsync(cancellationToken);

        return _mapper.Map<GetHotelsDto>(existingAttraction);
    }
}
