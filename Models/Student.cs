using System.ComponentModel.DataAnnotations;

namespace School34.Models;

public class Student
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(300)]
    public string? PhotoUrl { get; set; }

    [MaxLength(200)]
    public string? Reason { get; set; }

    public bool IsBest { get; set; }
}

