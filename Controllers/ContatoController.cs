using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hostello.Controllers;

public class ContatoController : Controller
{
    private readonly AppDbContext _db;

    public ContatoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var contatos = _db.Contatos.AsNoTracking().ToList();
        return View(contatos);
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
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var contato = _db.Contatos.Find(id);
        if(contato is null)
            return RedirectToAction("Index");
        return View(contato);
    }
    [HttpPost]
    public IActionResult Edit(int id, Contato contato)
    {
        var contatooriginal = _db.Contatos.Find(id);
        if(contatooriginal is null)
            return RedirectToAction("Index");

        contato.FkEstabelecimento = contatooriginal.FkEstabelecimento;
        if(!ModelState.IsValid)
            return View(contato);

        contatooriginal.Nome = contato.Nome;
        contatooriginal.Email = contato.Email;
        contatooriginal.Cargo = contato.Cargo;
        contatooriginal.Telefone = contato.Telefone;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var contato = _db.Contatos.Find(id);
        if(contato is null)
            return RedirectToAction("Index");
        return View(contato);
        
    }
    [HttpPost]
    public IActionResult ProcessDelete(Contato contato)
    {
        if(contato is null)
            return RedirectToAction("Index");
        _db.Contatos.Remove(contato);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


}