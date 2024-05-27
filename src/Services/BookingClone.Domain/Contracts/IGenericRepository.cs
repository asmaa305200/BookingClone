using BookingClone.Domain.Common;

namespace BookingClone.Domain.Contracts;

public interface IGenericRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    TEntity Add(TEntity entity);
    Task<int> DeleteAsync(TId id, CancellationToken ct = default);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct = default);
    Task<PagedList<TEntity>> GetPaginatedList(PaginationQuery query, CancellationToken ct = default);
    Task<int> SaveAsync(CancellationToken ct = default);
    TEntity Update(TEntity entity);
}