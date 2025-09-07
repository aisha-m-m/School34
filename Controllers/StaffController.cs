using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School34.Data;

namespace School34.Controllers;

public class StaffController : Controller
{
    private readonly SchoolContext _db;
    public StaffController(SchoolContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var staff = await _db.Staff.AsNoTracking().ToListAsync();
        return View(staff);
    }
}

