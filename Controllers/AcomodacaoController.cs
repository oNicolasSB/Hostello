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
        var acomodacoes = _db.Acomodacoes.Include(a=>a.Estabelecimento).Include(a=>a.TipoAcomodacao).ToList();
        return View(acomodacoes);
    }
    [HttpGet]
    public IActionResult Create()
    {
        CarregarTipoAcomodacao();
        var acomodacao = new Acomodacao();
        var estabelecimento = new Estabelecimento();
        estabelecimento.NomeFantasia = "Teste";
        estabelecimento.Celular = "99999999";
        estabelecimento.CNPJ = "24242";
        estabelecimento.MediaAvaliacao = 1;
        estabelecimento.RazaoSocial = "empresa 1";
        estabelecimento.TelefoneFixo = "242424242";
        _db.Estabelecimentos.Add(estabelecimento);
        _db.SaveChanges();

        acomodacao.FkEstabelecimento = estabelecimento.IdEstabelecimento;
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
    [HttpGet]
    public IActionResult Edit(int id)
    {
        CarregarTipoAcomodacao();
        var acomodacao = _db.Acomodacoes.Find(id);
        if(acomodacao is null)
            return RedirectToAction("Index");
        return View(acomodacao);
    }
    [HttpPost]
    public IActionResult Edit(int id, Acomodacao acomodacao)
    {

        var acomodacaooriginal = _db.Acomodacoes.Find(id);
        if(acomodacaooriginal is null)
            return RedirectToAction("Index");

        acomodacao.FkEstabelecimento = acomodacaooriginal.FkEstabelecimento;
        if(!ModelState.IsValid)
            return View(acomodacao);

        acomodacaooriginal.Descricao = acomodacao.Descricao;
        acomodacaooriginal.Numero = acomodacao.Numero;
        acomodacaooriginal.PessoasMax = acomodacao.PessoasMax;
        acomodacaooriginal.EstadiaMin = acomodacao.EstadiaMin;
        acomodacaooriginal.EstadiaMax = acomodacao.EstadiaMax;
        acomodacaooriginal.ValorDiaria = acomodacao.ValorDiaria;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var acomodacao = _db.Acomodacoes.Find(id);
        if(acomodacao is null)
            return RedirectToAction("Index");
        return View(acomodacao);
        
    }
    [HttpPost]
    public IActionResult ProcessDelete(Acomodacao acomodacao)
    {
        if(acomodacao is null)
            return RedirectToAction("Index");
        _db.Acomodacoes.Remove(acomodacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}