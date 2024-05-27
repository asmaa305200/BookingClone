using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public sealed class AttractionRepository : GenericRepository<Attraction, int>, IAttractionRepository
{
    public AttractionRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<Attraction>> GetAll(CancellationToken ct = default)
    => await _db.ToListAsync(ct);

    public async Task<Attraction?> GetAttractionDetails(int id, CancellationToken ct = default)
        => await _db.Include(a => a.Images)
            .FirstOrDefaultAsync(x => x.ID == id, ct);
}
