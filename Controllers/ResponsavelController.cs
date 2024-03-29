using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BCrypt.Net.BCrypt;

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
        if(_db.Usuarios.Any(u => u.Email == responsavelViewModel.Email))
        {
            ModelState.AddModelError("Email", "Já existe um usuário com este e-mail.");
            return View(responsavelViewModel);
        }
        var endereco = new Endereco();
        endereco.Logradouro = responsavelViewModel.Logradouro;
        endereco.Bairro = responsavelViewModel.Bairro;
        endereco.Numero = responsavelViewModel.Numero;
        endereco.Complemento = responsavelViewModel.Complemento;
        endereco.Cep = responsavelViewModel.Cep;
        endereco.Cidade = responsavelViewModel.Cidade;
        endereco.Estado = responsavelViewModel.Estado;
        endereco.Pais = responsavelViewModel.Pais;
        _db.Enderecos.Add(endereco);
        _db.SaveChanges();
        var responsavel = new Responsavel();
        responsavel.Nome = responsavelViewModel.Nome;
        responsavel.Cpf = responsavelViewModel.Cpf;
        responsavel.Email = responsavelViewModel.Email;
        responsavel.Senha = HashPassword(responsavelViewModel.Senha, 10);
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
        responsavel.FkEndereco = endereco.IdEndereco;
        _db.Responsaveis.Add(responsavel);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    [Authorize(Roles="responsavel")]
    public IActionResult Edit()
    {
        var responsavel = _db.Responsaveis.Find(Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value));
        responsavel.Senha = "";
        if(responsavel is null)
            return RedirectToAction("Index");
        return View(responsavel);
    }
    [HttpPost]
    [Authorize(Roles="responsavel")]
    public IActionResult Edit(int id, Responsavel responsavel)
    {
        ModelState.Remove("Cpf");
        ModelState.Remove("DataNascimento");
        ModelState.Remove("Sexo");
        ModelState.Remove("Senha");
        ModelState.Remove("CNPJ");
        if(!ModelState.IsValid){
            return View(responsavel);

        }
        var responsaveloriginal = _db.Responsaveis.Find(id);
        if(responsaveloriginal is null)
            return RedirectToAction("Index", "Home");
        responsaveloriginal.Nome = responsavel.Nome;
        responsaveloriginal.Email = responsavel.Email;
        responsaveloriginal.Telefone = responsavel.Telefone;
        responsaveloriginal.Celular = responsavel.Celular;
        responsaveloriginal.RazaoSocial = responsavel.RazaoSocial;
        responsaveloriginal.NomeFantasia = responsavel.NomeFantasia;
        responsaveloriginal.Senha = HashPassword(responsavel.Senha, 10);
        _db.SaveChanges();
        return RedirectToAction("Details", "Usuario");
    }
}