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
        _db.Responsaveis.Add(responsavel);
        var estabelecimento = new Estabelecimento();
        estabelecimento.CNPJ = responsavelViewModel.Cnpj;
        estabelecimento.NomeFantasia = responsavelViewModel.NomeFantasia;
        estabelecimento.TelefoneFixo = responsavelViewModel.Telefone;
        estabelecimento.Celular = responsavelViewModel.Celular;
        estabelecimento.RazaoSocial = responsavelViewModel.RazaoSocial;
        estabelecimento.MediaAvaliacao = null;
        _db.Estabelecimentos.Add(estabelecimento);

        _db.SaveChanges();
        return RedirectToAction("Create", "Endereco");

    }
}