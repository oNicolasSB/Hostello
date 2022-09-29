using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Cliente : Usuario
{
    public ICollection<Avaliacao> Avaliacoes { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
} 
