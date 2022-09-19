using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class EnderecoController : Controller
{
    private readonly AppDbContext _db;

    public EnderecoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var enderecos = _db.Enderecos.ToList();
        return View(enderecos);
    }
}