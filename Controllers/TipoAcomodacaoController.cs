using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class TipoAcomodacaoController : Controller
{
    private readonly AppDbContext _db;

    public TipoAcomodacaoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var tiposacomodacoes = _db.TiposAcomodacoes.ToList();
        return View(tiposacomodacoes);
    }
}