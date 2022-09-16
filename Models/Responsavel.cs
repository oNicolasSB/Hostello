using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Responsavel
{
    [Key]
    public int IdResponsavel { get; set; }
    [ForeignKey("Usuario")]
    public int FkUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public ICollection<Estabelecimento> Estabelecimentos { get; set; }
}