using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }
    [Required, StringLength(64)]
    public string Nome { get; set; }
}