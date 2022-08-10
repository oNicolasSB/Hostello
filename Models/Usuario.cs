using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    [Required, StringLength(128)]
    public string Nome { get; set; }
    [Required, StringLength(11)]
    public string Cpf { get; set; }
    [Required, StringLength(128)]
    public string Email { get; set; }
    [Required, StringLength(32)]
    public string Senha { get; set; }
    [StringLength(14)]
    public string Telefone { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public char Sexo { get; set; }
}