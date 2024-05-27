using MediatR;

namespace BookingClone.Application.Features.AttractionFeatures.Commands.DeleteAttraction;

public sealed class DeleteAttractionCommand : IRequest<int>
{
    public required int ID { get; set; }
}
