using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;

public interface IRoomReservationRepository : IGenericRepository<RoomReservation, int>
{
    Task<List<RoomReservation>> GetAll(CancellationToken ct = default);
}