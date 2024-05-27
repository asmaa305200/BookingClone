using BookingClone.Domain.Entities;
using BookingClone.Domain.Enums;

namespace BookingClone.Application.Features.RoomFeatures.DTOs;

public sealed class GetRoomDto
{
    public int ID { get; set; }
    public string RoomNumber { get; set; }

    public string Description { get; set; }

    public bool IsAvailable { get; set; }

    public int BedCount { get; set; }

    public RoomViewType ViewType { get; set; }

    public int HotelId { get; set; }
    public decimal Price { get; set; }

   


}
