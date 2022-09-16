using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
}