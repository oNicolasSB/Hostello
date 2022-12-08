using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class CadastroResponsavelViewModel
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
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string RazaoSocial { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string NomeFantasia { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(14)]
    public string Cnpj { get; set; }

    [StringLength(14)]
    public string Telefone { get; set; }
    [StringLength(14)]
    public string Celular { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int Sexo { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public string Numero { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Complemento { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(9)]
    public string Cep { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(64)]
    public string Cidade { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(64)]
    public string Estado { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string Pais { get; set; }
}