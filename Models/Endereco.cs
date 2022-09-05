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
    public int Numero { get; set; }
    [Required, StringLength(128)]
    public string Complemento { get; set; }
    [Required]
    public int Cep { get; set; }
    [Required, StringLength(64)]
    public string Cidade { get; set; }
    [Required, StringLength(64)]
    public string Estado { get; set; }
    [Required, StringLength(128)]
    public string Pais { get; set; }
    public ICollection<Cliente> Clientes { get; set; }
}