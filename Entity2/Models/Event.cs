namespace Entity2.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        // Navigation Property
        public int OrganizerId { get; set; }

        public Organizer Organizer { get; set; }
    }
}