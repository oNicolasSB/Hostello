using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hostello.Controllers;

public class AvaliacaoController : Controller
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public AvaliacaoController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }
    [Authorize(Roles="cliente, administrador, responsavel")]
    public IActionResult Index()
    {
        if(User.IsInRole("cliente"))
        {
            var cliente = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var avaliacoes = _db.Avaliacoes.Include(a=>a.Cliente).Where(a => a.FkCliente == cliente).AsNoTracking().ToList();
            return View(avaliacoes);
        } else if(User.IsInRole("administrador")){
            var avaliacoes = _db.Avaliacoes.Include(a=>a.Cliente).Where(a => a.Aprovado == null).AsNoTracking().ToList();
            return View(avaliacoes);
        } else {
            var responsavel = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var avaliacoes = _db.Avaliacoes.Include(a=>a.Acomodacao).ThenInclude(a => a.Responsavel).Where(a => a.Acomodacao.FkResponsavel == responsavel).Where(a => a.Aprovado == true).AsNoTracking().ToList();
            return View(avaliacoes);
        }
    }
    [Authorize(Roles="cliente")]
    [HttpGet]
    public IActionResult Create(int id)
    {
        var reserva = _db.Reservas.Find(id);
        var acomodacao = _db.Acomodacoes.Find(reserva.FkAcomodacao);
        if (reserva is null 
        //|| reserva.EstadiaSaida < DateTime.Now
         || reserva.FkCliente != Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value) || reserva.EstaPago is false){
            return RedirectToAction("Index", "Reserva");
        }
        var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{acomodacao.IdAcomodacao.ToString("D6")}";
        var di = new DirectoryInfo(pastaImagens);
        var imagens = di.GetFiles("*.jpg");
        @ViewBag.Imagens = new List<string>();
        foreach(var imagem in imagens)
        {
            var diretorio = imagem.ToString();
            var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
            @ViewBag.Imagens.Add(diretorioimagem);
        }
        acomodacao.QtdeImagens = imagens.Count();
        ViewBag.Acomodacao = acomodacao;
        var avaliacao = new Avaliacao();
        avaliacao.FkCliente = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        avaliacao.FkAcomodacao = id;
        return View(avaliacao);
    }
    [Authorize(Roles="cliente")]
    [HttpPost]
    public IActionResult Create(Avaliacao avaliacao)
    {
        if(!ModelState.IsValid) return View(avaliacao);
        _db.Avaliacoes.Add(avaliacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    // [HttpGet]
    // public IActionResult Delete(int id)
    // {
    //     var avaliacao = _db.Avaliacoes.Find(id);
    //     if(avaliacao is null)
    //         return RedirectToAction("Index");
    //     return View(avaliacao);
        
    // }
    // [HttpPost]
    // public IActionResult ProcessDelete(Avaliacao avaliacao)
    // {
    //     if(avaliacao is null)
    //         return RedirectToAction("Index");
    //     _db.Avaliacoes.Remove(avaliacao);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
    [HttpGet]
    public IActionResult Aprovar(int id)
    {
        var avaliacao = _db.Avaliacoes.Find(id);
        if(avaliacao is null)
            return RedirectToAction("Index");
        var aprovacao = new AprovacaoViewModel();
        aprovacao.IdAprovar = id;
        return View(aprovacao);
        
    }
    [HttpPost]
    public IActionResult ProcessAprovar(AprovacaoViewModel aprovacao)
    {
        if(!ModelState.IsValid) return RedirectToAction("Index");
        var avaliacao = _db.Avaliacoes.Find(aprovacao.IdAprovar);
        avaliacao.Aprovado = true;
        var acomodacao = _db.Acomodacoes.Find(avaliacao.FkAcomodacao);
        var avaliacoes = _db.Avaliacoes.Where(a => a.FkAcomodacao == avaliacao.FkAcomodacao).Where(a => a.Aprovado == true).ToList();
        double total = 0;
        int i = 0;
        foreach (var item in avaliacoes)
        {
            total += item.NotaAvaliacao;
            i++;
        }
        acomodacao.MediaAvaliacaoQuarto = total/i;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Reprovar(int id)
    {
        var avaliacao = _db.Avaliacoes.Find(id);
        if(avaliacao is null)
            return RedirectToAction("Index");
        var aprovacao = new AprovacaoViewModel();
        aprovacao.IdAprovar = id;
        return View(aprovacao);
        
    }
    [HttpPost]
    public IActionResult ProcessReprovar(AprovacaoViewModel aprovar)
    {
        if(!ModelState.IsValid) return RedirectToAction("Index");
        var avaliacao = _db.Avaliacoes.Find(aprovar.IdAprovar);
        avaliacao.Aprovado = false;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}