using hostello.Data;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class PagamentoController : Controller
{
    private readonly AppDbContext _db;

    public PagamentoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
}