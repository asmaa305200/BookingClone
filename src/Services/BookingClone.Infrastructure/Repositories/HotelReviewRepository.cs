using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public sealed class HotelReviewRepository : GenericRepository<HotelReview, int>, IHotelReviewRepository
{
    public HotelReviewRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<HotelReview>> GetAll(CancellationToken ct = default)
        => await _db.ToListAsync(ct);


}
