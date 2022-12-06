using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Acomodacao
{
    [Key]
    public int IdAcomodacao { get; set; }
    public double? MediaAvaliacaoQuarto { get; set; }
    [Required, StringLength(256)]
    public string Descricao { get; set; }
    public int Numero { get; set; }
    public int PessoasMax { get; set; }
    public int EstadiaMin { get; set; }
    public int EstadiaMax { get; set; }
    public double ValorDiaria { get; set; }
    [ForeignKey("Administrador")]
    public int? FkAdministrador { get; set; }
    [ForeignKey("TipoAcomodacao")]
    public int FkTipoAcomodacao { get; set; }
    [ForeignKey("Responsavel")]
    public int FkResponsavel { get; set; }
    public Administrador Administrador { get; set; }
    public TipoAcomodacao TipoAcomodacao { get; set; }
    public Responsavel Responsavel { get; set; }
    public ICollection<Aluguel> Alugueis { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }

    [NotMapped, Required(ErrorMessage = "Imagem não enviada.")]
    [Display(Name = "Arquivo da Imagem")]
    public List<IFormFile> ArquivosImagens { get; set; }

    [NotMapped]
    public string CaminhoPasta
    {
        get
        {
            var CaminhoPasta = Path.Combine(
                $"\\img\\acomodacao\\", this.IdAcomodacao.ToString("D6"));
            return CaminhoPasta;

            // CaminhosImagens.Add("//img//acomodacao000000//000000.jpg");
            // int i = 0;
            // foreach (var imagem in ArquivosImagens)
            // {
            //     i++;
            //     CaminhosImagens.Add(Path.Combine(
            //     $"//img//acomodacao{IdAcomodacao.ToString("D6")}//{i.ToString("D6")}.jpg"));
            // }
            // return CaminhosImagens;
        }
    }
    [NotMapped]
    public int QtdeImagens { get; set; }
}