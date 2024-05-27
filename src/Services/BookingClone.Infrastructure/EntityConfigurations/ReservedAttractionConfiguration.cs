using BookingClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingClone.Infrastructure.EntityConfigurations;

internal sealed class ReservedAttractionConfiguration : IEntityTypeConfiguration<ReservedAttraction>
{
    public void Configure(EntityTypeBuilder<ReservedAttraction> builder)
    {
        builder.HasKey(ra => new { ra.AttractionID, ra.AttractionReservationID });
    }
}
