using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(11)]
    public string Cpf { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(32)]
    public string Senha { get; set; }
    [StringLength(14)]
    public string Telefone { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime DataNascimento { get; set; }
    public EnumSexo Sexo { get; set; }
}