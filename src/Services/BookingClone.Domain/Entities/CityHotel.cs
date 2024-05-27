namespace BookingClone.Domain.Entities;

public sealed class CityHotel
{
    public int CityID { get; set; }

    public int HotelID { get; set; }

    public City City { get; set; }

    public Hotel Hotel { get; set; }

    public string Address { get; set; }
}
