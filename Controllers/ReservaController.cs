using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ReservaController : Controller
{
    private readonly AppDbContext _db;

    public ReservaController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var reservas = _db.Reservas.ToList();
        return View(reservas);
    }
}