using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ItemReservaController : Controller
{
    private readonly AppDbContext _db;

    public ItemReservaController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var itensreserva = _db.ItensReserva.ToList();
        return View(itensreserva);
    }
}