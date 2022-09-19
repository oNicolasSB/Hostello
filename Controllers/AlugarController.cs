using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class AlugarController : Controller
{
    private readonly AppDbContext _db;

    public AlugarController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
}