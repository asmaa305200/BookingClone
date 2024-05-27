using BookingClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingClone.Infrastructure.EntityConfigurations;

internal sealed class AttractionImageConfiguration : IEntityTypeConfiguration<AttractionImage>
{
    public void Configure(EntityTypeBuilder<AttractionImage> builder)
    {
        builder.Property(a => a.ImageUrlPath).HasMaxLength(250);

        builder.HasKey(a => new { a.ID, a.ImageUrlPath });

        builder.HasOne(i => i.Attraction)
            .WithMany(a => a.Images)
            .HasForeignKey(i => i.ID);
    }
}
