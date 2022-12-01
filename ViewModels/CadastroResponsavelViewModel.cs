using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class CadastroResponsavelViewModel
{
    [Key]
    public int IdCadastroResponsavel { get; set; }

    public string Nome { get; set; }

    [Required, StringLength(11)]
    public string Cpf { get; set; }

    [Required, StringLength(128)]
    public string Email { get; set; }

    [Required, StringLength(32)]
    public string Senha { get; set; }

    [Required, StringLength(32)]
    [Compare(nameof(Senha), ErrorMessage = "Os campos {0} e {1} devem ser iguais.")]
    public string ConfSenha { get; set; }
    [Required, StringLength(128)]
    public string RazaoSocial { get; set; }
    [Required, StringLength(128)]
    public string NomeFantasia { get; set; }
    [Required, StringLength(14)]
    public string Cnpj { get; set; }

    [StringLength(14)]
    public string Telefone { get; set; }
    [StringLength(14)]
    public string Celular { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    public int Sexo { get; set; }
    [Required, StringLength(128)]
    public string Logradouro { get; set; }
    [Required, StringLength(128)]
    public string Bairro { get; set; }
    [Required]
    public string Numero { get; set; }
    [Required, StringLength(128)]
    public string Complemento { get; set; }
    [Required, StringLength(9)]
    public string Cep { get; set; }
    [Required, StringLength(64)]
    public string Cidade { get; set; }
    [Required, StringLength(64)]
    public string Estado { get; set; }
    [Required, StringLength(128)]
    public string Pais { get; set; }
}