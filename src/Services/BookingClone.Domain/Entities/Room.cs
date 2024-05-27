using BookingClone.Domain.Common;
using BookingClone.Domain.Enums;

namespace BookingClone.Domain.Entities;

public sealed class Room : BaseEntity<int>
{
    public string RoomNumber { get; set; }

    public string Description { get; set; }

    public bool IsAvailable { get; set; }

    public int BedCount { get; set; }

    public RoomViewType ViewType { get; set; }

    public decimal Price { get; set; }
    
    public int HotelId { get; set; }
    
    public Hotel Hotel { get; set; }

    public List<ReservedRoom> ReservedRooms { get; set; }
}
