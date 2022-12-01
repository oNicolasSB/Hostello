using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class ResponsavelController : Controller
{
    private readonly AppDbContext _db;

    public ResponsavelController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var responsaveis = _db.Responsaveis.ToList();
        return View(responsaveis);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var responsavel = new CadastroResponsavelViewModel();
        return View(responsavel);
    }
    [HttpPost]
    public IActionResult Create(CadastroResponsavelViewModel responsavelViewModel)
    {
        if(!ModelState.IsValid) return View(responsavelViewModel);
        var responsavel = new Responsavel();
        responsavel.Nome = responsavelViewModel.Nome;
        responsavel.Cpf = responsavelViewModel.Cpf;
        responsavel.Email = responsavelViewModel.Email;
        responsavel.Senha = responsavelViewModel.Senha;
        responsavel.Telefone = responsavelViewModel.Telefone;
        responsavel.DataNascimento = responsavelViewModel.DataNascimento;
        if(responsavelViewModel.Sexo == 0){
            responsavel.Sexo = EnumSexo.NaoInformado;
        } else if (responsavelViewModel.Sexo == 1){
            responsavel.Sexo = EnumSexo.Masculino;
        } else {
            responsavel.Sexo = EnumSexo.Feminino;
        }
        
        responsavel.CNPJ = responsavelViewModel.Cnpj;
        responsavel.NomeFantasia = responsavelViewModel.NomeFantasia;
        responsavel.Celular = responsavelViewModel.Celular;
        responsavel.RazaoSocial = responsavelViewModel.RazaoSocial;
        responsavel.MediaAvaliacao = null;
        _db.Responsaveis.Add(responsavel);
        _db.SaveChanges();
        return RedirectToAction("Create", "Endereco");

    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var responsavel = _db.Responsaveis.Find(id);
        if(responsavel is null)
            return RedirectToAction("Index");
        return View(responsavel);
    }
    [HttpPost]
    public IActionResult Edit(int id, Responsavel responsavel)
    {
        var responsaveloriginal = _db.Responsaveis.Find(id);
        Responsavel controle = responsavel;
        ModelState.Remove("IdUsuario");
        ModelState.Remove("Cpf");
        ModelState.Remove("DataNascimento");
        ModelState.Remove("Sexo");
        ModelState.Remove("Senha");
        ModelState.Remove("RazaoSocial");
        ModelState.Remove("CNPJ");
        if(responsaveloriginal is null)
            return RedirectToAction("Index");

        responsaveloriginal.Nome = responsavel.Nome;
        responsaveloriginal.Email = responsavel.Email;
        responsaveloriginal.Telefone = responsavel.Telefone;
        responsaveloriginal.Celular = responsavel.Celular;
        responsaveloriginal.RazaoSocial = responsavel.RazaoSocial;
        responsaveloriginal.NomeFantasia = responsavel.NomeFantasia;
        _db.SaveChanges();
        return RedirectToAction("IndexResponsavel", "Home");
    }
}