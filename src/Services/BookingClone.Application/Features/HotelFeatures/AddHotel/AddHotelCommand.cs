using BookingClone.Application.Features.HotelFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.AddHotel;

public sealed class AddHotelCommand : IRequest<GetHotelsDto>
{
    public AddHotelDto Dto { get; set; }
}
