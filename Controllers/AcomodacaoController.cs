using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class AcomodacaoController : Controller
{
    private readonly AppDbContext _db;

    public AcomodacaoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var acomodacoes = _db.Acomodacoes.ToList();
        return View(acomodacoes);
    }

    public IActionResult Create()
    {
        var acomodacao = new Acomodacao();
        return View(acomodacao);
    }
}