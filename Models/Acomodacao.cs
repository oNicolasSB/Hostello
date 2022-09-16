using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Acomodacao
{
    [Key]
    public int IdAcomodacao { get; set; }
    public double MediaAvaliacaoQuarto { get; set; }
    [Required, StringLength(256)]
    public string Descricao { get; set; }
    public int Numero { get; set; }
    public int PessoasMax { get; set; }
    public int EstadiaMin { get; set; }
    public double ValorDiaria { get; set; }
    [ForeignKey("TipoAcomodacao")]
    public int FkTipoAcomodacao { get; set; }
    [ForeignKey("Estabelecimento")]
    public int FkEstabelecimento { get; set; }
    public TipoAcomodacao TipoAcomodacao { get; set; }
    public Estabelecimento Estabelecimento { get; set; }
    public ICollection<ItemReserva> ItensReserva { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
}