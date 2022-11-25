using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Mvc;
using static BCrypt.Net.BCrypt;

namespace hostello.Controllers;

public class UsuarioController : Controller
{
    private readonly AppDbContext _db;

    public UsuarioController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var usuarios = _db.Usuarios.ToList();
        return View(usuarios);
    }
    [HttpGet]
    public IActionResult Login()
    {
        var login = new LoginViewModel();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
    {
        if(!ModelState.IsValid) return View(login);
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == login.Email);
        if (usuario is null)
        {
            ModelState.AddModelError("Email", "Email não cadastrado");
            return View(login);
        }

        string hashSenha = HashPassword(login.Senha);
        string hashSenhaUsuario = HashPassword(usuario.Senha);
        var verificador = Verify(hashSenha, hashSenhaUsuario);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Name, usuario.Nome),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            IsPersistent = login.Lembrar,
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        System.Console.WriteLine($"O Usuário {usuario.Email} logou às {DateTime.Now}");

        if (returnUrl is null) return RedirectToAction(nameof(Index));
        return RedirectToAction(returnUrl);
    }
}