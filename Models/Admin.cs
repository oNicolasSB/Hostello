using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Admin
{
    [Key]
    public int IdAdmin { get; set; }
    [ForeignKey("Usuario")]
    public int FkUsuario { get; set; }
    public Usuario Usuario { get; set; }
}