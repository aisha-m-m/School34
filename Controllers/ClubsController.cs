using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School34.Data;

namespace School34.Controllers;

public class ClubsController : Controller
{
    private readonly SchoolContext _db;
    public ClubsController(SchoolContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var clubs = await _db.Clubs.AsNoTracking().ToListAsync();
        return View(clubs);
    }
}

