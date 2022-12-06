using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class Endereco
{
    [Key]
    public int IdEndereco { get; set; }
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