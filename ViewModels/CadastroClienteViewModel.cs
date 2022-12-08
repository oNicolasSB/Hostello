using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class CadastroClienteViewModel
{
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(11)]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(32)]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(32)]
    [Compare(nameof(Senha), ErrorMessage = "Os campos {0} e {1} devem ser iguais.")]
    public string ConfSenha { get; set; }

    [StringLength(14)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int Sexo { get; set; }
}