using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.AttractionReviewFeatures.DTOs;

public class GetAttractionReviewDto

{
    public int ID { get; set; }

    public string Comment { get; set; }

    public int AttractionID { get; set; }
}

