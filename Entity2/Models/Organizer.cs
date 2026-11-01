using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity2.Models;

[Table("EventOrganizers")]
public class Organizer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }

    public bool IsVerified { get; set; }

    // Relationship: Organizer and OrganizerProfile (One-to-One)
    public OrganizerProfile? OrganizerProfile { get; set; }

    // Relationship: Organizer and Event (One-to-Many)
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
