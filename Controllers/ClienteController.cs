using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ClienteController : Controller
{
    private readonly AppDbContext _db;

    public ClienteController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var clientes = _db.Clientes.ToList();
        return View(clientes);
    }
}