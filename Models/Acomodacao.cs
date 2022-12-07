using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Acomodacao
{
    [Key]
    public int IdAcomodacao { get; set; }
    public double? MediaAvaliacaoQuarto { get; set; }
    
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(256)]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int Numero { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int PessoasMax { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int EstadiaMin { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int EstadiaMax { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
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
    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }

    [NotMapped, Required(ErrorMessage = "Imagem não enviada.")]
    [Display(Name = "Arquivo da Imagem")]
    public List<IFormFile> ArquivosImagens { get; set; }
    [NotMapped]
    public int QtdeImagens { get; set; }
}