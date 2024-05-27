using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;

public interface IAttractionReservationRepository : IGenericRepository<AttractionReservation, int>
{
    Task<List<AttractionReservation>> GetAll(CancellationToken ct = default);
    Task<List<ReservedAttraction>> GetAllReservedAttractionsDetails(int reservationId, CancellationToken ct = default);
    Task<ReservedAttraction?> GetReservationDetails(int reservationId, int attractionId, CancellationToken ct = default);
}