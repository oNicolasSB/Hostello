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

    public void CarregarMaxPessoas(int idAcomodacao)
    {
        var acomodacao = _db.Acomodacoes.Find(idAcomodacao);
        List<int> listMaxPessoas = new List<int>();
        for (int i = 0; i < acomodacao.PessoasMax; i++)
        {
            listMaxPessoas.Add(i);
        }
        var selectMaxPessoas = new SelectList(listMaxPessoas);
        ViewBag.SelectMaxPessoas = selectMaxPessoas;
    }

    public void CarregarEstadiaMax(int idAcomodacao)
    {
        var acomodacao = _db.Acomodacoes.Find(idAcomodacao);
        List<int> listEstadiaMax = new List<int>();
        for (int i = 0; i < acomodacao.EstadiaMax; i++)
        {
            listEstadiaMax.Add(i);
        }
        var selectEstadiaMax = new SelectList(listEstadiaMax);
        ViewBag.SelectEstadiaMax = selectEstadiaMax;
    }

    [Authorize(Roles = "cliente")]
    [HttpGet]
    public IActionResult Index(int id)
    {
        CarregarMaxPessoas(id);
        CarregarEstadiaMax(id);

        var aluguel = new Aluguel();

        return View(aluguel);
    }

    [HttpPost]
    public IActionResult Index(Aluguel aluguel)
    {
        var valorDiaria = _db.Acomodacoes.Find(aluguel.FkAcomodacao).ValorDiaria;
        aluguel.DataSaida = aluguel.DataEntrada.AddDays(aluguel.QtdeDias);
        aluguel.Valor = aluguel.QtdeDias*aluguel.
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