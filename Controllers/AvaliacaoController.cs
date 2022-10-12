using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var avaliacoes = _db.Avaliacoes.Include(a=>a.Cliente).AsNoTracking().ToList();
        return View(avaliacoes);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var avaliacao = new Avaliacao();
        return View(avaliacao);
    }
    [HttpPost]
    public IActionResult Create(Avaliacao avaliacao)
    {
        if(!ModelState.IsValid) return View(avaliacao);
        _db.Avaliacoes.Add(avaliacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var avaliacao = _db.Avaliacoes.Find(id);
        if(avaliacao is null)
            return RedirectToAction("Index");
        return View(avaliacao);
        
    }
    [HttpPost]
    public IActionResult ProcessDelete(Avaliacao avaliacao)
    {
        if(avaliacao is null)
            return RedirectToAction("Index");
        _db.Avaliacoes.Remove(avaliacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}