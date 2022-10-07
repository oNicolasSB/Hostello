using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Cliente : Usuario
{
    [ForeignKey("Endereco")]
    public int? FkEndereco { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    public Endereco Endereco { get; set; }
} 
