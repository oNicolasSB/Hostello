using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    [Required]
    public ICollection<Endereco> Enderecos { get; set; }
    [ForeignKey("Usuario")]
    public int FkUsuario { get; set; }
} 
