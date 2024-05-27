using System;
using MediatR;
using BookingClone.Application.Features.HotelReviewFeatures.DTOs;

namespace BookingClone.Application.Features.HotelReviewFeatures.Queries.GetHotelReviewById;

public sealed class GetHotelReviewByIdQuery : IRequest<GetHotelReviewDto?>
{
    public required int ID { get; init; }
}

