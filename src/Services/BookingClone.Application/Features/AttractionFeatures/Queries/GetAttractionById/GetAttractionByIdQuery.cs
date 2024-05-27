using BookingClone.Application.Features.AttractionFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Queries.GetAttractionById;

public sealed class GetAttractionByIdQuery : IRequest<GetAttractionDto?>
{
    public required int ID { get; set; }
}
