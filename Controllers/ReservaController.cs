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
    [Authorize(Roles = "cliente, administrador, responsavel")]
    public IActionResult Index()
    {
        @ViewBag.Imagens = new List<string>();
        if (User.IsInRole("cliente"))
        {
            var cliente = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var reservas = _db.Reservas.Include(a => a.Cliente).Include(a => a.Acomodacao).ThenInclude(a => a.Responsavel).Where(a => a.FkCliente == cliente).ToList();
            foreach (var reserva in reservas)
            {
                var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{reserva.FkAcomodacao.ToString("D6")}";
                var di = new DirectoryInfo(pastaImagens);
                var imagens = di.GetFiles("*.jpg");
                var diretorio = imagens[0].ToString();
                var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
                @ViewBag.Imagens.Add(diretorioimagem);
            }
            return View(reservas);
        }else if(User.IsInRole("responsavel")){
            var responsavel = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var reservas = _db.Reservas.Include(a => a.Cliente).Include(a => a.Acomodacao).ThenInclude(a => a.Responsavel).Where(a => a.Acomodacao.FkResponsavel == responsavel).Where(a => a.EstaPago == true).ToList();
            foreach (var reserva in reservas)
            {
                var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{reserva.FkAcomodacao.ToString("D6")}";
                var di = new DirectoryInfo(pastaImagens);
                var imagens = di.GetFiles("*.jpg");
                var diretorio = imagens[0].ToString();
                var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
                @ViewBag.Imagens.Add(diretorioimagem);
            }
            return View(reservas);
        } else {
            var reservas = _db.Reservas.Include(a => a.Cliente).Include(a => a.Acomodacao).ThenInclude(a => a.Responsavel).AsNoTracking().ToList();
            foreach (var reserva in reservas)
            {
                var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{reserva.FkAcomodacao.ToString("D6")}";
                var di = new DirectoryInfo(pastaImagens);
                var imagens = di.GetFiles("*.jpg");
                var diretorio = imagens[0].ToString();
                var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
                @ViewBag.Imagens.Add(diretorioimagem);
            }
            return View(reservas);
        }
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
        @ViewBag.Imagens = new List<string>();
        foreach(var imagem in imagens)
        {
            var diretorio = imagem.ToString();
            var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
            @ViewBag.Imagens.Add(diretorioimagem);
        }
        var reserva = new Reserva();
        reserva.EstaPago = false;
        reserva.EstadiaEntrada = DateTime.Today.AddDays(1);
        int fkAcomodacao = id;
        reserva.FkAcomodacao = fkAcomodacao;
        reserva.FkCliente = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        return View(reserva);
    }

    [Authorize(Roles = "cliente")]
    [HttpPost]
    public IActionResult Create(Reserva reserva)
    {
        ModelState.Remove("DataReserva");
        ModelState.Remove("EstadiaEntrada");
        ModelState.Remove("ValorReserva");
        if(!ModelState.IsValid)
        {
            return RedirectToAction("Create", "Reserva", reserva.FkAcomodacao);
        }
        reserva.DataReserva = DateTime.Now;
        reserva.EstadiaSaida = reserva.EstadiaEntrada.AddDays(reserva.PeriodoEstadia);
        reserva.ValorReserva = reserva.ValorReserva * reserva.PeriodoEstadia;
        _db.Reservas.Add(reserva);
        _db.SaveChanges();
        return RedirectToAction("Pagamento", "Reserva", new {fkReserva = reserva.IdReserva});
    }

    [Authorize(Roles = "cliente")]
    [HttpGet]
    public IActionResult Pagamento(int fkReserva)
    {
        if(_db.Reservas.Find(fkReserva) is null) 
        {
            return RedirectToAction("Index", "Acomodacao");
        }
        var pagamento = new PagamentoViewModel();
        pagamento.FkReserva = fkReserva;
        return View(pagamento);
    }
    [Authorize(Roles = "cliente")]
    [HttpPost]
    public IActionResult Pagamento(PagamentoViewModel pagamento)
    {
        if(!ModelState.IsValid)
        {
            return View(pagamento);
        }
        var reserva = _db.Reservas.Find(pagamento.FkReserva);
        var hoje = DateTime.Now;
        reserva.EstaPago = true;
        reserva.DataPagamento = hoje;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}