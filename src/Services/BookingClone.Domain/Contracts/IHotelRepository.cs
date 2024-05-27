using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;

public interface IHotelRepository : IGenericRepository<Hotel, int>
{
    Task<List<Hotel>> GetAllHotel(CancellationToken ct = default);
}
