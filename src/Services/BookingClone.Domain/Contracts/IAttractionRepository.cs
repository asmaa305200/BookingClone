using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;

public interface IAttractionRepository : IGenericRepository<Attraction, int>
{
    Task<List<Attraction>> GetAll(CancellationToken ct = default);
    Task<Attraction?> GetAttractionDetails(int id, CancellationToken ct = default);
}