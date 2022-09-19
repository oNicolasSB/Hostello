using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class EstabelecimentoController : Controller
{
    private readonly AppDbContext _db;

    public EstabelecimentoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var estabelecimentos = _db.Estabelecimentos.ToList();
        return View(estabelecimentos);
    }
}