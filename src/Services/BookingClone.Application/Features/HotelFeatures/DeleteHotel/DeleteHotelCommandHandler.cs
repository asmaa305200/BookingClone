using BookingClone.Domain.Contracts;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.DeleteHotel;

public sealed class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, int>
{
    private readonly IHotelRepository _hotelRepository;

    public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<int> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        return await _hotelRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
