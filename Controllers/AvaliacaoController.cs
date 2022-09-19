using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class AvaliacaoController : Controller
{
    private readonly AppDbContext _db;

    public AvaliacaoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var avaliacoes = _db.Avaliacoes.ToList();
        return View(avaliacoes);
    }
}