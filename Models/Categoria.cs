using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(64)]
    public string Nome { get; set; }
}