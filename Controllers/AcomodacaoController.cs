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
    [HttpGet]
    public IActionResult Create()
    {
        var acomodacao = new Acomodacao();
        acomodacao.FkEstabelecimento = 1;
        acomodacao.FkTipoAcomodacao = 1;
        return View(acomodacao);
    }
    [HttpPost]
    public IActionResult Create(Acomodacao acomodacao)
    {
        if(!ModelState.IsValid) return View(acomodacao);
        _db.Acomodacoes.Add(acomodacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}