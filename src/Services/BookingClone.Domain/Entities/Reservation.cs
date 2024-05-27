using BookingClone.Domain.Common;
using BookingClone.Domain.Enums;

namespace BookingClone.Domain.Entities;

public abstract class Reservation : BaseEntity<int>
{
    public decimal TotalCost { get; set; }

    public ReservationStatus Status { get; set; }
}
