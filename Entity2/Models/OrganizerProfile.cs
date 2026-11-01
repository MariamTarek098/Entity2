
namespace Entity2.Models
{
    public class OrganizerProfile
    {
        public int OrganizerId { get; set; }

        public string? Biography { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }

        public Organizer Organizer { get; set; }
    }
}