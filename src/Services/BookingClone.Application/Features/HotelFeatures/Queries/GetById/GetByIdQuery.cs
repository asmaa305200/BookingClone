using BookingClone.Application.Features.HotelFeatures.DTOs;
using MediatR;

namespace BookingClone.Application.Features.HotelFeatures.Queries.GetById;

public sealed class GetByIdQuery : IRequest<GetHotelsDto>
{
    public int ID { get; set; }
}
