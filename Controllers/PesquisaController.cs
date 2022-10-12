using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hostello.Controllers;

public class PesquisaController : Controller
{
    private readonly AppDbContext _db;

    public PesquisaController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var acomodacoes = _db.Acomodacoes.Include(a=>a.Estabelecimento).Include(a=>a.Estabelecimento.Endereco).AsNoTracking().ToList();
        return View(acomodacoes);
    }
}