using BookingClone.Domain.Common;

namespace BookingClone.Domain.Entities;

public sealed class City : BaseEntity<int>
{
    public string Name { get; set; }
    
    public int? CountryID { get; set; }
    
    public Country Country { get; set; }

    public List<Attraction>? Attractions { get; set; }

    public List<CityHotel>? CityHotels { get; set; }  
}
