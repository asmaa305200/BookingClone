using BookingClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingClone.Infrastructure.EntityConfigurations;

internal sealed class ReservedRoomConfiguration : IEntityTypeConfiguration<ReservedRoom>
{
    public void Configure(EntityTypeBuilder<ReservedRoom> builder)
    {
        builder.HasKey(rr => new { rr.RoomID, rr.RoomReservationID });
    }
}
