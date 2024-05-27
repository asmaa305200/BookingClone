using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.DeleteHotel;

public sealed class DeleteHotelCommand : IRequest<int>
{
    public int Id { get; set; }
}
