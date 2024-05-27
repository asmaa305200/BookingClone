using BookingClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingClone.Infrastructure.EntityConfigurations;

internal sealed class CityHotelConfiguration : IEntityTypeConfiguration<CityHotel>
{
    public void Configure(EntityTypeBuilder<CityHotel> builder)
    {
        builder.HasKey(ch => new { ch.CityID, ch.HotelID });
    }
}
