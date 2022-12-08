using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BCrypt.Net.BCrypt;

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
    [Authorize(Roles = "administrador")]
    public IActionResult Edit()
    {
        var administrador = _db.Administradores.Find(Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value));
        if(administrador is null)
            return RedirectToAction("Index", "Home");
        return View(administrador);
    }
    [HttpPost]
    [Authorize(Roles = "administrador")]
    public IActionResult Edit(int id, Administrador administrador)
    {
        ModelState.Remove("Cpf");
        ModelState.Remove("DataNascimento");
        ModelState.Remove("Sexo");
        if (!ModelState.IsValid)
        {
            return View(administrador);
        }
        var administradororiginal = _db.Usuarios.Find(id);
        if(administradororiginal is null)
            return RedirectToAction("Index", "Home");

        administradororiginal.Nome = administrador.Nome;
        administradororiginal.Email = administrador.Email;
        administradororiginal.Senha = HashPassword(administrador.Senha, 10);
        administradororiginal.Telefone = administrador.Telefone;
        _db.SaveChanges();
        return RedirectToAction("Details", "Usuario");
    }
}