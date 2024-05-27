using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public class RoomRepository : GenericRepository<Room, int>, IRoomRepository
{
    public RoomRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<Room>> GetAll(CancellationToken ct = default)
        => await _db.ToListAsync(ct);

    public async Task<Room?> GetRoomDetails(int id, CancellationToken ct = default)
        => await _db.Include(a => a.Hotel).FirstOrDefaultAsync(a => a.ID == id, ct);
}
