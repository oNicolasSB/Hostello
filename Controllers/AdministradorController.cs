using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class AdministradorController : Controller
{
    private readonly AppDbContext _db;

    public AdministradorController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var administradores = _db.Administradores.ToList();
        return View(administradores);
    }
}