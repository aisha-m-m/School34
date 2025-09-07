using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School34.Data;

namespace School34.Controllers;

public class StudentsController : Controller
{
    private readonly SchoolContext _db;
    public StudentsController(SchoolContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var best = await _db.Students.AsNoTracking().Where(s => s.IsBest).ToListAsync();
        return View(best);
    }
}

