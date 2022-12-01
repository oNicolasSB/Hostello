using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "cliente")]
    public IActionResult Index()
    {
        var acomodacoes = _db.Acomodacoes.Include(a=>a.Responsavel).Include(a=>a.Responsavel.Endereco).AsNoTracking().ToList();
        return View(acomodacoes);
    }
}