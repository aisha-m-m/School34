using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School34.Data;
using School34.Models;

namespace School34.Controllers;

public class ScheduleController : Controller
{
    private readonly SchoolContext _db;
    public ScheduleController(SchoolContext db) => _db = db;

    public async Task<IActionResult> Index(string? cls)
    {
        var classes = await _db.ScheduleEntries.Select(s => s.ClassName).Distinct().OrderBy(s => s).ToListAsync();
        cls ??= classes.FirstOrDefault();
        var entries = await _db.ScheduleEntries.AsNoTracking()
            .Where(s => s.ClassName == cls)
            .OrderBy(s => s.Day).ThenBy(s => s.Time)
            .ToListAsync();
        ViewBag.Classes = classes;
        ViewBag.CurrentClass = cls;
        return View(entries);
    }

    [Authorize]
    public IActionResult Create(string? cls)
    {
        return View(new ScheduleEntry { ClassName = cls ?? "11", Day = DayOfWeek.Monday, Time = new TimeOnly(12,0), Subject = "Математика" });
    }

    [Authorize, HttpPost]
    public async Task<IActionResult> Create(ScheduleEntry entry)
    {
        if (!ModelState.IsValid) return View(entry);
        _db.ScheduleEntries.Add(entry);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { cls = entry.ClassName });
    }

    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        var entry = await _db.ScheduleEntries.FindAsync(id);
        if (entry == null) return NotFound();
        return View(entry);
    }

    [Authorize, HttpPost]
    public async Task<IActionResult> Edit(int id, ScheduleEntry entry)
    {
        if (id != entry.Id) return BadRequest();
        if (!ModelState.IsValid) return View(entry);
        _db.Entry(entry).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { cls = entry.ClassName });
    }

    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var entry = await _db.ScheduleEntries.FindAsync(id);
        if (entry == null) return NotFound();
        _db.ScheduleEntries.Remove(entry);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index), new { cls = entry.ClassName });
    }
}

