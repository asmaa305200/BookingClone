using BookingClone.Application.Features.AttractionFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.AddAttraction;

public sealed class AddAttractionCommand : IRequest<GetAttractionDto>
{
    public required AddAttractionDto Dto { get; set; }
}
