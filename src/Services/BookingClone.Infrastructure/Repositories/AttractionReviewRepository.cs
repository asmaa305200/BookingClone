using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public sealed class AttractionReviewRepository : GenericRepository<AttractionReview, int>, IAttractionReviewRepository
{
    public AttractionReviewRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<AttractionReview>> GetAll(CancellationToken ct = default)
        => await _db.ToListAsync(ct);
}
