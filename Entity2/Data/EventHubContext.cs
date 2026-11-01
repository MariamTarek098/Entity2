using Entity2.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity2.Data
{
    public class EventHubContext : DbContext
    {
        // Constructor with DbContextOptions
        public EventHubContext(DbContextOptions<EventHubContext> options)
            : base(options)
        {
        }

        // Parameterless Constructor
        public EventHubContext()
        {
        }

        // DbSets
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        // Configure Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Organizer - OrganizerProfile (One-to-One)
            modelBuilder.Entity<OrganizerProfile>()
                .HasKey(p => p.OrganizerId);

            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.OrganizerProfile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);

            // Organizer - Event (One-to-Many)
            modelBuilder.Entity<Organizer>()
                .HasMany(o => o.Events)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId);

            // Badge Configuration (Separate Configuration Class)
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }
    }
}