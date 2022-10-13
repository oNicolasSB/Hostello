using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class AdministradorController : Controller
{
    private readonly AppDbContext _db;

    public AdministradorController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var administradores = _db.Administradores.ToList();
        return View(administradores);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var administrador = _db.Usuarios.Find(id);
        if(administrador is null)
            return RedirectToAction("IndexAdmin", "Home");
        return View(administrador);
    }
    [HttpPost]
    public IActionResult Edit(int id, Administrador administrador)
    {
        var administradororiginal = _db.Usuarios.Find(id);
        Administrador teste = administrador;
        if(teste.Nome=="" || teste.Email=="" || teste.Senha=="" || teste.Telefone==""){
            return View(administrador);
        }
        if(administradororiginal is null)
            return RedirectToAction("Index");

        administradororiginal.Nome = administrador.Nome;
        administradororiginal.Email = administrador.Email;
        administradororiginal.Senha = administrador.Senha;
        administradororiginal.Telefone = administrador.Telefone;
        _db.SaveChanges();
        return RedirectToAction("IndexAdmin", "Home");
    }
}