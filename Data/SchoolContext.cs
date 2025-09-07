using Microsoft.EntityFrameworkCore;
using School34.Models;

namespace School34.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<StaffMember> Staff => Set<StaffMember>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Club> Clubs => Set<Club>();
    public DbSet<ScheduleEntry> ScheduleEntries => Set<ScheduleEntry>();
}

