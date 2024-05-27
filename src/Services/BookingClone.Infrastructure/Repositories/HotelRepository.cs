using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public sealed class HotelRepository : GenericRepository<Hotel, int>, IHotelRepository
{
    public HotelRepository(BookingDbContext context) : base(context)
    { }

    public async Task<List<Hotel>> GetAllHotel(CancellationToken ct = default)
         => await _db.ToListAsync(ct);
}

