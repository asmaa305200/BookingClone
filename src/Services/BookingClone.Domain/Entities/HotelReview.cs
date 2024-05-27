namespace BookingClone.Domain.Entities;

public sealed class HotelReview : Review
{
    public string? PositiveReview { get; set; }

    public string? NegativeReview { get; set; }

    public decimal ComfortRate { get; set; }
    
    public decimal StaffRate { get; set; }
    
    public decimal FacilitiesRate { get; set; }
    
    public decimal ValueForMoneyRate { get; set; }
    
    public decimal CleanlinessRate { get; set; }
    
    public decimal LocationRate { get; set; }

    public int HotelID { get; set; }

    public Hotel Hotel { get; set; }
}
