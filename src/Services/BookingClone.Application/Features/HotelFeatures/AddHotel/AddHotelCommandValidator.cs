using FluentValidation;

namespace BookingClone.Application.Features.HotelFeatures.AddHotel;

public sealed class AddHotelCommandValidator : AbstractValidator<AddHotelCommand>
{
    public AddHotelCommandValidator()
    {
        
    }
}
