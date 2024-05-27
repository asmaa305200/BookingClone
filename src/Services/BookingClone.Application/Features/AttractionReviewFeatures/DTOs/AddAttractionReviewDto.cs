using BookingClone.Domain.Entities;

namespace BookingClone.Application.Features.AttractionReviewFeatures.DTOs;

public class AddAttractionReviewDto
{
    public string Comment { get; set; }

    public int AttractionID { get; set; }
}

