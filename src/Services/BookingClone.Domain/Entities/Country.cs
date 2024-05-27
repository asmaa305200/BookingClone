using BookingClone.Domain.Common;

namespace BookingClone.Domain.Entities;

public sealed class Country : BaseEntity<int>
{
    

    public string Name { get; set; }

    public Continent Continent { get; set; }

    public int? ContinentID { get; set; }
    public List<City>? Cities { get; set; }

   
}
