using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BCrypt.Net.BCrypt;

namespace hostello.Controllers;

public class ClienteController : Controller
{
    private readonly AppDbContext _db;

    public ClienteController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var clientes = _db.Clientes.ToList();
        return View(clientes);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var cliente = new CadastroClienteViewModel();
        return View(cliente);
    }
    [HttpPost]
    public IActionResult Create(CadastroClienteViewModel clienteViewModel)
    {
        if(!ModelState.IsValid) return View(clienteViewModel);
        if(_db.Usuarios.Any(u => u.Email == clienteViewModel.Email))
        {
            ModelState.AddModelError("Email", "Já existe um usuário com este e-mail.");
            return View(clienteViewModel);
        }
        var cliente = new Cliente();
        cliente.Nome = clienteViewModel.Nome;
        cliente.Cpf = clienteViewModel.Cpf;
        cliente.Email = clienteViewModel.Email;
        cliente.Senha = HashPassword(clienteViewModel.Senha, 10);
        cliente.Telefone = clienteViewModel.Telefone;
        cliente.DataNascimento = clienteViewModel.DataNascimento;
        if(clienteViewModel.Sexo == 0){
            cliente.Sexo = EnumSexo.NaoInformado;
        } else if (clienteViewModel.Sexo == 1){
            cliente.Sexo = EnumSexo.Masculino;
        } else {
            cliente.Sexo = EnumSexo.Feminino;
        }
        _db.Clientes.Add(cliente);
        _db.SaveChanges();
        return RedirectToAction("Index");

    }
    [HttpGet]
    [Authorize(Roles = "cliente")]
    public IActionResult Edit()
    {
        var cliente = _db.Usuarios.Find(Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value));
        if(cliente is null)
            return RedirectToAction("Index", "Home");
        return View(cliente);
    }
    [HttpPost]
    [Authorize(Roles = "cliente")]
    public IActionResult Edit(int id, Cliente cliente)
    {
        ModelState.Remove("Cpf");
        ModelState.Remove("DataNascimento");
        ModelState.Remove("Sexo");
        if(!ModelState.IsValid){
            return View(cliente);
        }
        var clienteoriginal = _db.Usuarios.Find(id);
        if(clienteoriginal is null)
            return RedirectToAction("Index", "Home");

        clienteoriginal.Nome = cliente.Nome;
        clienteoriginal.Email = cliente.Email;
        clienteoriginal.Senha = HashPassword(cliente.Senha, 10);
        clienteoriginal.Telefone = cliente.Telefone;
        _db.SaveChanges();
        return RedirectToAction("Details", "Usuario");
    }
}