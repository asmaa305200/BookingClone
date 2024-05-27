using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public sealed class RoomReservationRepository : GenericRepository<RoomReservation, int>, IRoomReservationRepository
{
    public RoomReservationRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<RoomReservation>> GetAll(CancellationToken ct = default)
        => await _db.ToListAsync(ct);
}
