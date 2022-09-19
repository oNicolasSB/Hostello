using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class UsuarioController : Controller
{
    private readonly AppDbContext _db;

    public UsuarioController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var usuarios = _db.Usuarios.ToList();
        return View(usuarios);
    }
}