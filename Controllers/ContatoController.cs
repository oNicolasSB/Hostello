using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "responsavel, administrador")]
    public IActionResult Index()
    {
        if(User.IsInRole("responsavel")){
        int id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        var contatos = _db.Contatos.Where(a => a.FkResponsavel == id).AsNoTracking().ToList();
            return View(contatos);
        } else {
            var contatos = _db.Contatos.AsNoTracking().ToList();
            return View(contatos);
        }
    }

    [Authorize(Roles= "responsavel")]
    [HttpGet]
    public IActionResult Create()
    {
        var contato = new Contato();
        contato.FkResponsavel = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        return View(contato);
    }
    [Authorize(Roles = "responsavel")]
    [HttpPost]
    public IActionResult Create(Contato contato)
    {
        if(!ModelState.IsValid) return View(contato);
        _db.Contatos.Add(contato);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [Authorize(Roles = "responsavel")]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var contato = _db.Contatos.Find(id);
        if(contato is null)
            return RedirectToAction("Index");
        return View(contato);
    }
    [Authorize(Roles = "responsavel")]
    [HttpPost]
    public IActionResult Edit(int id, Contato contato)
    {
        var contatooriginal = _db.Contatos.Find(id);
        if(contatooriginal is null)
            return RedirectToAction("Index");

        contato.FkResponsavel = contatooriginal.FkResponsavel;
        if(!ModelState.IsValid)
            return View(contato);

        contatooriginal.Nome = contato.Nome;
        contatooriginal.Email = contato.Email;
        contatooriginal.Cargo = contato.Cargo;
        contatooriginal.Telefone = contato.Telefone;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "responsavel")]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var contato = _db.Contatos.Find(id);
        if(contato is null)
            return RedirectToAction("Index");
        return View(contato);
        
    }
    [Authorize(Roles = "responsavel")]
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