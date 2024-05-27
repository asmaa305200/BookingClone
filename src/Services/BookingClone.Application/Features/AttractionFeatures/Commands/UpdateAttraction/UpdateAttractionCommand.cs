using BookingClone.Application.Features.AttractionFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.UpdateAttraction;

public sealed class UpdateAttractionCommand : IRequest<GetAttractionDto?>
{
    public required UpdateAttractionDto Dto { get; set; }
}
