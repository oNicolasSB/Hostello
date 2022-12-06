using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Contato
{
    [Key]
    public int IdContato { get; set; }
    
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    [StringLength(64, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(14)]
    public string Telefone { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(64)]
    public string Cargo { get; set; }
    [ForeignKey("Estabelecimento")]
    public int FkEstabelecimento { get; set; }
    public Estabelecimento Estabelecimento { get; set; }
}