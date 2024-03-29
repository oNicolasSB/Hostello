using System.Security.Claims;
using hostello.Data;
using hostello.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace hostello.Controllers;

public class AcomodacaoController : Controller
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public AcomodacaoController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    private void CarregarTipoAcomodacao(int? idSelectedTipoAcomodacao = null)
    {
        var tiposAcomodacoes = _db.TiposAcomodacoes.AsNoTracking().OrderBy(p => p.NomeTipoAcomodacao).ToList();
        var selectTiposAcomodacoes = new SelectList(tiposAcomodacoes, "IdTipoAcomodacao", "NomeTipoAcomodacao", idSelectedTipoAcomodacao);
        ViewBag.SelectTiposAcomodacoes = selectTiposAcomodacoes;
    }
    [Authorize(Roles = "responsavel, administrador")]
    public IActionResult Index()
    {
        @ViewBag.Imagens = new List<string>();
        if (User.IsInRole("responsavel"))
        {
            var responsavel = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            var acomodacoes = _db.Acomodacoes.Include(a => a.Responsavel).Include(a => a.TipoAcomodacao).Where(a => a.FkResponsavel == responsavel).ToList();
            foreach (var acomodacao in acomodacoes)
            {
                var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{acomodacao.IdAcomodacao.ToString("D6")}";
                var di = new DirectoryInfo(pastaImagens);
                var imagens = di.GetFiles("*.jpg");
                var diretorio = imagens[0].ToString();
                var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
                @ViewBag.Imagens.Add(diretorioimagem);
            }
            return View(acomodacoes);
        } else
        {
            var acomodacoes = _db.Acomodacoes.Include(a => a.Responsavel).Include(a => a.TipoAcomodacao).Where(a => a.Aprovado == null).ToList();
            foreach (var acomodacao in acomodacoes)
            {
                var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{acomodacao.IdAcomodacao.ToString("D6")}";
                var di = new DirectoryInfo(pastaImagens);
                var imagens = di.GetFiles("*.jpg");
                var diretorio = imagens[0].ToString();
                var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
                @ViewBag.Imagens.Add(diretorioimagem);
            }
            return View(acomodacoes);
        }

    }
    [HttpGet]
    [Authorize(Roles = "responsavel")]
    public IActionResult Create()
    {
        CarregarTipoAcomodacao();
        var acomodacao = new Acomodacao();
        // var estabelecimento = new Estabelecimento();
        // estabelecimento.NomeFantasia = "Teste";
        // estabelecimento.Celular = "99999999";
        // estabelecimento.CNPJ = "24242";
        // estabelecimento.MediaAvaliacao = 1;
        // estabelecimento.RazaoSocial = "empresa 1";
        // estabelecimento.TelefoneFixo = "242424242";
        // _db.Estabelecimentos.Add(estabelecimento);
        // _db.SaveChanges();

        acomodacao.FkResponsavel = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
        acomodacao.MediaAvaliacaoQuarto = null;
        return View(acomodacao);
    }
    [HttpPost]
    [Authorize(Roles = "responsavel")]
    public IActionResult Create(Acomodacao acomodacao)
    {
        if (!ModelState.IsValid)
        {
            CarregarTipoAcomodacao();
            return View(acomodacao);
        }
        _db.Acomodacoes.Add(acomodacao);
        if (_db.SaveChanges() > 0)
        {
            foreach (var imagem in acomodacao.ArquivosImagens)
            {
                var pastaimagens = CarregarPastaImagens(acomodacao.IdAcomodacao);
                if (!Directory.Exists(pastaimagens))
                {
                    Directory.CreateDirectory(pastaimagens);
                }
                var caminhoimagem = $"{pastaimagens}//{acomodacao.ArquivosImagens.IndexOf(imagem).ToString("D6")}.jpg";
                SalvarUploadImagemAsync(caminhoimagem, imagem).Wait();
            }
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    [Authorize(Roles = "responsavel")]
    public IActionResult Edit(int id)
    {
        CarregarTipoAcomodacao();
        var acomodacao = _db.Acomodacoes.Include(a => a.Responsavel).Include(a => a.TipoAcomodacao).FirstOrDefault(a => a.IdAcomodacao == id);
        var imagens = CarregarImagens(acomodacao.IdAcomodacao);
        @ViewBag.Imagens = new List<string>();
        foreach(var imagem in imagens)
        {
            var diretorio = imagem.ToString();
            var diretorioimagem = diretorio.Replace($"{_env.WebRootPath}", "");
            @ViewBag.Imagens.Add(diretorioimagem);
        }
        acomodacao.QtdeImagens = imagens.Count();
        if (acomodacao is null)
            return RedirectToAction("Index");
        return View(acomodacao);
    }
    [HttpPost]
    [Authorize(Roles = "responsavel")]
    public IActionResult Edit(int id, Acomodacao acomodacao)
    {

        var acomodacaooriginal = _db.Acomodacoes.Find(id);
        if (acomodacaooriginal is null)
            return RedirectToAction("Index");

        acomodacao.FkResponsavel = acomodacaooriginal.FkResponsavel;
        if (!ModelState.IsValid)
            return View(acomodacao);

        acomodacaooriginal.Descricao = acomodacao.Descricao;
        acomodacaooriginal.Numero = acomodacao.Numero;
        acomodacaooriginal.PessoasMax = acomodacao.PessoasMax;
        acomodacaooriginal.EstadiaMin = acomodacao.EstadiaMin;
        acomodacaooriginal.EstadiaMax = acomodacao.EstadiaMax;
        acomodacaooriginal.ValorDiaria = acomodacao.ValorDiaria;
        _db.SaveChanges();
        if (acomodacao.ArquivosImagens is not null)
        {
            var imagens = CarregarImagens(id);
            var ultimo = Convert.ToInt32(imagens.Last().Name.Replace(".jpg", ""));
            for (int i = 0; i < acomodacao.ArquivosImagens.Count(); i++)
            {
                var caminhoimagem = $"{CarregarPastaImagens(id)}\\{(i + ultimo + 1).ToString("D6")}.jpg";
                SalvarUploadImagemAsync(caminhoimagem, acomodacao.ArquivosImagens.ElementAt(i)).Wait();
            }
        }
        return RedirectToAction("Index");
    }
    [Authorize(Roles="responsavel")]
    [HttpGet]
    public IActionResult DeleteImage(int idacomodacao, string caminhoimagem)
    {
        var imagemDelete = new ImagemDeleteViewModel();
        imagemDelete.CaminhoImagem = caminhoimagem;
        imagemDelete.IdAcomodacao = idacomodacao;
        return View(imagemDelete);

    }
    [Authorize(Roles="responsavel")]
    [HttpPost]
    public IActionResult ProccesDeleteImagem(ImagemDeleteViewModel imagemDelete)
    {
        FileInfo imagem = new FileInfo($"{_env.WebRootPath}\\{imagemDelete.CaminhoImagem}");
        if(imagem.Exists)
        {
            imagem.Delete();
        }
        return RedirectToAction("Edit", "Acomodacao", new {id = imagemDelete.IdAcomodacao});
    }

    public string CarregarPastaImagens(int idAcomodacao)
    {
        var pastaImagens = $"{_env.WebRootPath}\\img\\acomodacao\\{idAcomodacao.ToString("D6")}";
        return pastaImagens;
    }

    public FileInfo[] CarregarImagens(int idAcomodacao)
    {
        
        var di = new DirectoryInfo(CarregarPastaImagens(idAcomodacao));
        var imagens = di.GetFiles("*.jpg");
        return imagens;
    }

    [HttpGet]
    [Authorize(Roles = "responsavel")]
    public IActionResult Delete(int id)
    {
        var acomodacao = _db.Acomodacoes.Find(id);
        if (acomodacao is null)
            return RedirectToAction("Index");
        return View(acomodacao);
    }
    [HttpPost]
    [Authorize(Roles = "responsavel")]
    public IActionResult ProcessDelete(Acomodacao acomodacao)
    {
        if (acomodacao is null)
            return RedirectToAction("Index");
        _db.Acomodacoes.Remove(acomodacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Aprovar(int id)
    {
        var avaliacao = _db.Acomodacoes.Find(id);
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
        var avaliacao = _db.Acomodacoes.Find(aprovacao.IdAprovar);
        avaliacao.Aprovado = true;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Reprovar(int id)
    {
        var avaliacao = _db.Acomodacoes.Find(id);
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
        var avaliacao = _db.Acomodacoes.Find(aprovar.IdAprovar);
        avaliacao.Aprovado = false;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public async Task<bool> SalvarUploadImagemAsync(
        string caminhoArquivoImagem, IFormFile imagem, bool salvarQuadrada = true)
    {
        if (imagem is null)
        {
            return false;
        }
        var ms = new MemoryStream();
        await imagem.CopyToAsync(ms);
        ms.Position = 0;
        var img = await Image.LoadAsync(ms);
        if (salvarQuadrada)
        {
            var tamanho = img.Size();
            var ladoMenor = (tamanho.Height < tamanho.Width) ? tamanho.Height : tamanho.Width; // um if escrito de forma estranha

            img.Mutate(i =>
                i.Resize(new ResizeOptions()
                {
                    Size = new Size(ladoMenor, ladoMenor),
                    Mode = ResizeMode.Crop
                })
            );
        }
        await img.SaveAsJpegAsync(caminhoArquivoImagem);
        return true;
    }
}