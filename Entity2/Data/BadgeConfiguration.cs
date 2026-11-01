
using Entity2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity2.Data
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            // Primary Key
            builder.HasKey(b => b.Id);

            // Attendee - Badge (One-to-One)
            builder.HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId);

            // BadgeNumber must be unique
            builder.HasIndex(b => b.BadgeNumber)
                .IsUnique();
        }
    }
}

