using BookingClone.Domain.Common;

namespace BookingClone.Domain.Entities;

public abstract class Review : BaseEntity<int>
{
    public DateTimeOffset ReviewDate { get; set; }
}
