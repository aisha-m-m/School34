using System.ComponentModel.DataAnnotations;

namespace School34.Models;

public class StaffMember
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Role { get; set; } = string.Empty;

    [MaxLength(300)]
    public string? PhotoUrl { get; set; }
}

