using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class Endereco
{
    [Key]
    public int IdEndereco { get; set; }
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