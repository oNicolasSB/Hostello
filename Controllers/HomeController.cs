using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hostello.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult IndexAdmin()
    {
        var admin = _db.Administradores.Find(3);
        return View(admin);
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Recuperar()
    {
        return View();
    }
    public IActionResult IndexResponsavel()
    {
         var admin = _db.Responsaveis.Find(1);
        return View(admin);
    }
}