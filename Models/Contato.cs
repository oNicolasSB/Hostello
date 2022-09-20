using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Contato
{
    [Key]
    public int IdContato { get; set; }
    [Required, StringLength(128)]
    public string Nome { get; set; }
    [Required, StringLength(14)]
    public string Telefone { get; set; }
    [Required, StringLength(128)]
    public string Email { get; set; }
    [Required, StringLength(64)]
    public string Cargo { get; set; }
    [ForeignKey("Estabelecimento")]
    public int FkEstabelecimento { get; set; }
    public Estabelecimento Estabelecimento { get; set; }
}