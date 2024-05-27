using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;

public interface IHotelReviewRepository : IGenericRepository<HotelReview, int>
{
    Task<List<HotelReview>> GetAll(CancellationToken ct = default);
    
    
}