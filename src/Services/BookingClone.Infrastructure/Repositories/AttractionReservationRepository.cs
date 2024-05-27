using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;

public sealed class AttractionReservationRepository : GenericRepository<AttractionReservation, int>, IAttractionReservationRepository
{
    public AttractionReservationRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<AttractionReservation>> GetAll(CancellationToken ct = default)
        => await _db.ToListAsync(ct);

    public async Task<List<ReservedAttraction>> GetAllReservedAttractionsDetails(int reservationId, CancellationToken ct = default)
    {
        AttractionReservation? attractionReservation = await _db.Include(x => x.ReservedAttractions)
                    .FirstOrDefaultAsync(x => x.ID == reservationId);

        return attractionReservation.ReservedAttractions;
    }

    public async Task<ReservedAttraction?> GetReservationDetails(int reservationId, int attractionId, CancellationToken ct = default)
    {
        AttractionReservation? attractionReservation = await _db.Include(x => x.ReservedAttractions)
            .FirstOrDefaultAsync(x => x.ID == reservationId, ct);

        return attractionReservation.ReservedAttractions.FirstOrDefault(a => a.AttractionID == attractionId);
    }
}
