using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class AdminController : Controller
{
    private readonly AppDbContext _db;

    public AdminController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var admins = _db.Admins.ToList();
        return View(admins);
    }
}