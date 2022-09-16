using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }
    [ForeignKey("Usuario")]
    public int FkUsuario { get; set; }
    [ForeignKey("Endereco")]
    public int FkEndereco { get; set; }
    public Usuario Usuario { get; set; }
    public Endereco Endereco { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
} 
