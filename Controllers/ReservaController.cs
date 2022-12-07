using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hostello.Controllers;

public class ReservaController : Controller
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public ReservaController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    public void CarregarMaxPessoas(int idAcomodacao)
    {
        var acomodacao = _db.Acomodacoes.Find(idAcomodacao);
        List<int> listMaxPessoas = new List<int>();
        for (int i = 0; i < acomodacao.PessoasMax; i++)
        {
            listMaxPessoas.Add(i+1);
        }
        var selectMaxPessoas = new SelectList(listMaxPessoas);
        ViewBag.SelectMaxPessoas = selectMaxPessoas;
    }

    public void CarregarEstadia(int idAcomodacao)
    {
        var acomodacao = _db.Acomodacoes.Find(idAcomodacao);
        var estadiaMax = acomodacao.EstadiaMax;
        var estadiaMin = acomodacao.EstadiaMin;
        List<int> listEstadia = new List<int>();
        for (int i = estadiaMin; i <= acomodacao.EstadiaMax; i++)
        {
            listEstadia.Add(i);
        }
        var selectEstadiaMax = new SelectList(listEstadia);
        ViewBag.SelectEstadiaMax = selectEstadiaMax;
    }

    public void CarregarAcomodacao(int idAcomodacao)
    {
        var acomodacao = _db.Acomodacoes.Find(idAcomodacao);
        _db.Acomodacoes.Include(a => a.Responsavel).Load();
        var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{idAcomodacao.ToString("D6")}";
        var di = new DirectoryInfo(pastaImagens);
        var imagens = di.GetFiles("*.jpg");
        acomodacao.QtdeImagens = imagens.Count();

        ViewBag.Acomodacao = acomodacao;
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
        CarregarEstadia(id);
        CarregarMaxPessoas(id);
        CarregarAcomodacao(id);
        var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{id.ToString("D6")}";
        var di = new DirectoryInfo(pastaImagens);
        var imagens = di.GetFiles("*.jpg");
        var reserva = new Reserva();
        reserva.EstaPago = false;
        reserva.EstadiaEntrada = DateTime.Today;
        reserva.FkAcomodacao = id;
        reserva.FkCliente = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        return View(reserva);
    }

    [Authorize(Roles = "cliente")]
    [HttpPost]
    public IActionResult Create(Reserva reserva)
    {
        reserva.DataReserva = DateTime.Now;
        reserva.EstadiaSaida = reserva.EstadiaEntrada.AddDays(reserva.PeriodoEstadia);
        reserva.ValorReserva = reserva.ValorReserva * reserva.PeriodoEstadia;
        if(!ModelState.IsValid)
        {
            return View(reserva);
        }
        _db.Reservas.Add(reserva);
        _db.SaveChanges();
        return RedirectToAction("Pagamento");
    }
}