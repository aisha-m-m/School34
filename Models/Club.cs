using System.ComponentModel.DataAnnotations;

namespace School34.Models;

public class Club
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(300)]
    public string? PhotoUrl { get; set; }
}

