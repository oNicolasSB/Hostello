using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hostello.Controllers;

public class AcomodacaoController : Controller
{
    private readonly AppDbContext _db;

    public AcomodacaoController(AppDbContext db)
    {
        _db = db;
    }

    private void CarregarTipoAcomodacao(int? idSelectedTipoAcomodacao = null)
    {
        var tiposAcomodacoes = _db.TiposAcomodacoes.AsNoTracking().OrderBy(p => p.NomeTipoAcomodacao).ToList();
        var selectTiposAcomodacoes = new SelectList(tiposAcomodacoes, "IdTipoAcomodacao", "NomeTipoAcomodacao", idSelectedTipoAcomodacao);
        ViewBag.SelectTiposAcomodacoes = selectTiposAcomodacoes;
    }

    public IActionResult Index()
    {
        var acomodacoes = _db.Acomodacoes.ToList();
        return View(acomodacoes);
    }
    [HttpGet]
    public IActionResult Create()
    {
        CarregarTipoAcomodacao();
        var acomodacao = new Acomodacao();
        acomodacao.FkEstabelecimento = 1;
        acomodacao.MediaAvaliacaoQuarto = null;
        return View(acomodacao);
    }
    [HttpPost]
    public IActionResult Create(Acomodacao acomodacao)
    {
        if(!ModelState.IsValid)
        {
            CarregarTipoAcomodacao();
            return View(acomodacao);
        }
        _db.Acomodacoes.Add(acomodacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}