using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ClienteController : Controller
{
    private readonly AppDbContext _db;

    public ClienteController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var clientes = _db.Clientes.ToList();
        return View(clientes);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var cliente = new Cliente();
        return View(cliente);
    }
    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        if(!ModelState.IsValid) return View(cliente);
        _db.Clientes.Add(cliente);
        _db.SaveChanges();
        return RedirectToAction("Index");

    }
}