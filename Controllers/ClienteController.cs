using hostello.Data;
using hostello.Models;
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
    public IActionResult Details()
    {
        var cliente = _db.Clientes.Find(2);
        return View(cliente);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cliente = _db.Usuarios.Find(id);
        if(cliente is null)
            return RedirectToAction("Details", "Cliente");
        return View(cliente);
    }
    [HttpPost]
    public IActionResult Edit(int id, Cliente cliente)
    {
        var clienteoriginal = _db.Usuarios.Find(id);
        Cliente teste = cliente;
        if(clienteoriginal is null)
            return RedirectToAction("Details", "Cliente");

        clienteoriginal.Nome = cliente.Nome;
        clienteoriginal.Email = cliente.Email;
        clienteoriginal.Senha = cliente.Senha;
        clienteoriginal.Telefone = cliente.Telefone;
        _db.SaveChanges();
        return RedirectToAction("Details", "Cliente");
    }
}