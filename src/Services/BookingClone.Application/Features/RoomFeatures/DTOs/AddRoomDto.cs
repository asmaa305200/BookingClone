using BookingClone.Domain.Enums;

namespace BookingClone.Application.Features.RoomFeatures.DTOs;

public class AddRoomDto
{
    public string RoomNumber { get; set; }

    public string Description { get; set; }

    public bool IsAvailable { get; set; }

    public int BedCount { get; set; }

    public RoomViewType ViewType { get; set; }

    public decimal Price { get; set; }

    public int HotelId { get; set; }
}
