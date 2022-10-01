using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostello.Controllers;

public class EnderecoController : Controller
{
    private readonly AppDbContext _db;

    public EnderecoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index(int p=1)
    {
        var enderecos = _db.Enderecos.Skip((p-1)*5).Take(5).ToList(); //paginação
        return View(enderecos);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var endereco = new Endereco();
        return View(endereco);
    }
    [HttpPost]
    public IActionResult Create(Endereco endereco)
    {
        if(!ModelState.IsValid) return View(endereco);
        _db.Enderecos.Add(endereco);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var endereco = _db.Enderecos.Find(id);
        if(endereco is null)
            return RedirectToAction("Index");
        return View(endereco);
    }
    [HttpPost]
    public IActionResult Edit(int id, Endereco endereco)
    {
        var enderecooriginal = _db.Enderecos.Find(id);
        if(enderecooriginal is null)
            return RedirectToAction("Index");

        if(!ModelState.IsValid)
            return View(endereco);
        
        enderecooriginal.Logradouro = endereco.Logradouro;
        enderecooriginal.Bairro = endereco.Bairro;
        enderecooriginal.Numero = endereco.Numero;
        enderecooriginal.Complemento = endereco.Complemento;
        enderecooriginal.Cep = endereco.Cep;
        enderecooriginal.Cidade = endereco.Cidade;
        enderecooriginal.Estado = endereco.Estado;
        enderecooriginal.Pais = endereco.Pais;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var endereco = _db.Enderecos.Find(id);
        if(endereco is null)
            return RedirectToAction("Index");
        return View(endereco);
        
    }
    [HttpPost]
    public IActionResult ProcessDelete(int idEndereco)
    {
        var endereco = _db.Enderecos.Find(idEndereco);
        if(endereco is null)
            return RedirectToAction("Index");
        _db.Enderecos.Remove(endereco);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}