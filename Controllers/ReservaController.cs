using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hostello.Controllers;

public class ReservaController : Controller
{
    private readonly AppDbContext _db;

    public ReservaController(AppDbContext db)
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

    public IActionResult Index()
    {
        var reservas = _db.Reservas.ToList();
        return View(reservas);
    }
    [Authorize(Roles = "cliente")]
    [HttpGet]
    public IActionResult Create(int id)
    {
        CarregarMaxPessoas(id);
        CarregarEstadiaMax(id);
        var reserva = new Reserva();
        return View(reserva);
    }

    [Authorize(Roles = "cliente")]
    [HttpPost]
    public IActionResult Create(Reserva reserva)
    {
        var valorDiaria = _db.Acomodacoes.Find(reserva.FkAcomodacao).ValorDiaria;
        reserva.DataReserva = DateTime.Now;
        reserva.QtdeDias = Convert.ToInt32(reserva.EstadiaEntrada.Subtract(reserva.EstadiaSaida).TotalDays);
        reserva.EstadiaSaida = reserva.EstadiaEntrada.AddDays(reserva.QtdeDias);
        reserva.ValorReserva = reserva.Acomodacao.ValorDiaria * reserva.QtdeDias;
        if(!ModelState.IsValid)
        {
            return View(reserva);
        }
        _db.Reservas.Add(reserva);
        _db.SaveChanges();
        RedirectToAction("Index");
    }
}