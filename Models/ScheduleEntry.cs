using System.ComponentModel.DataAnnotations;

namespace School34.Models;

public class ScheduleEntry
{
    public int Id { get; set; }

    [Required, MaxLength(10)]
    public string ClassName { get; set; } = string.Empty; // e.g. "11"

    [Required]
    public DayOfWeek Day { get; set; }

    [Required]
    public TimeOnly Time { get; set; }

    [Required, MaxLength(100)]
    public string Subject { get; set; } = string.Empty;
}

