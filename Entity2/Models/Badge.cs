namespace Entity2.Models
{
    public enum BadgeTier
    {
        Standard,
        VIP
    }

    public class Badge
    {
        public int Id { get; set; }

        public string BadgeNumber { get; set; }

        public DateTime IssueDate { get; set; }

        public BadgeTier Tier { get; set; }

        // Navigation Property
        public int AttendeeId { get; set; }

        public Attendee Attendee { get; set; }
    }
}