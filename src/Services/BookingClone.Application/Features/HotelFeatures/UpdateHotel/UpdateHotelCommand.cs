using BookingClone.Application.Features.HotelFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.UpdateHotel;

public sealed class UpdateHotelCommand : IRequest<GetHotelsDto>
{
    public UpdateHotelDto Dto { get; set; }
}
