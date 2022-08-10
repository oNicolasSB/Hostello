using System.ComponentModel.DataAnnotations;

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
    public ICollection<ItemReserva> ItensReserva { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
}