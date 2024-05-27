using BookingClone.Application.Features.AttractionFeatures.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.AddAttractionImage;

public sealed class AddAttractionImageCommand : IRequest<List<AttractionImageDto>?>
{
    public required int ID { get; set; }

    public required List<IFormFile> Images { get; set; }
}
