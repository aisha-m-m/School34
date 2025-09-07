using School34.Data;
using School34.Models;

namespace School34.Services;

public static class DbInitializer
{
    private static readonly string[] Subjects = new[]
    {
        "Математика", "Русский язык", "Литература", "Физика", "Химия", "История", "Биология", "География", "Информатика", "Английский"
    };

    public static void Seed(SchoolContext db)
    {
        if (!db.Staff.Any())
        {
            db.Staff.AddRange(new[]
            {
                new StaffMember { Name = "Иванова Мария Петровна", Role = "Директор", PhotoUrl = "/images/staff-director.svg" },
                new StaffMember { Name = "Петров Сергей Иванович", Role = "Завуч", PhotoUrl = "/images/staff-zavuch.svg" },
                new StaffMember { Name = "Сидорова Анна Викторовна", Role = "Учитель математики", PhotoUrl = "/images/staff-math.svg" },
                new StaffMember { Name = "Кузнецов Алексей Андреевич", Role = "Учитель информатики", PhotoUrl = "/images/staff-it.svg" },
            });
        }

        if (!db.Clubs.Any())
        {
            db.Clubs.AddRange(new[]
            {
                new Club { Name = "Робототехника", Description = "Занятия по роботам и Arduino", PhotoUrl = "/images/club-robotics.svg" },
                new Club { Name = "Футбол", Description = "Спортивная секция по футболу", PhotoUrl = "/images/club-football.svg" },
                new Club { Name = "Театр", Description = "Актерское мастерство и сцена", PhotoUrl = "/images/club-theater.svg" },
            });
        }

        if (!db.Students.Any())
        {
            db.Students.AddRange(new[]
            {
                new Student { Name = "Алексей Смирнов", Reason = "Победитель олимпиады", IsBest = true, PhotoUrl = "/images/student-2.svg" },
                new Student { Name = "Екатерина Морозова", Reason = "Отличная успеваемость", IsBest = true, PhotoUrl = "/images/student-1.svg" },
                new Student { Name = "Дмитрий Ковалев", Reason = "Активист школы", IsBest = true, PhotoUrl = "/images/student-3.svg" },
            });
        }

        if (!db.ScheduleEntries.Any())
        {
            var rnd = new Random(34);
            var times = new[] { new TimeOnly(9,0), new TimeOnly(10,0), new TimeOnly(11,0), new TimeOnly(12,0) };
            foreach (var cls in Enumerable.Range(1, 11).Select(i => i.ToString()))
            {
                foreach (var day in new[]{ DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday })
                {
                    foreach (var t in times)
                    {
                        db.ScheduleEntries.Add(new ScheduleEntry
                        {
                            ClassName = cls,
                            Day = day,
                            Time = t,
                            Subject = Subjects[rnd.Next(Subjects.Length)]
                        });
                    }
                }
            }
        }

        db.SaveChanges();
    }
}
