using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hostello.Controllers;

public class AlugarController : Controller
{
    private readonly AppDbContext _db;

    public AlugarController(AppDbContext db)
    {
        _db = db;
    }

    public void CarregarMaxPessoas(int idAcomodacao){
        
        List<int> listMaxPessoas = new List<int>();
        for (int i = 0; i < idAcomodacao; i++)
        {
            listMaxPessoas.Add(i);
        }
        var selectMaxPessoas = new SelectList(listMaxPessoas);
        ViewBag.SelectMaxPessoas = selectMaxPessoas;

    }
    [Authorize("cliente")]
    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult Alugar(int IdAcomodacao)
    // {
    //     var acomodacao = _db.Acomodacoes.Find(IdAcomodacao);
    //     if(acomodacao is null)
    //         return RedirectToAction("Index", "Pesquisa");
    //     CarregarMaxPessoas(acomodacao.PessoasMax);
    //     return View(acomodacao);
    // }
}