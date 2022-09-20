using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ContatoController : Controller
{
    private readonly AppDbContext _db;

    public ContatoController(AppDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public IActionResult Create()
    {
        var contato = new Contato();
        contato.FkEstabelecimento = 1;
        return View(contato);
    }
    [HttpPost]
    public IActionResult Create(Contato contato)
    {
        if(!ModelState.IsValid) return View(contato);
        _db.Contatos.Add(contato);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}