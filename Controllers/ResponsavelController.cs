using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ResponsavelController : Controller
{
    private readonly AppDbContext _db;

    public ResponsavelController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var responsaveis = _db.Responsaveis.ToList();
        return View(responsaveis);
    }
}