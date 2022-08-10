using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class Estabelecimento
{
    [Key]
    public int IdEstabelecimento { get; set; }
    [Required, StringLength(14)]
    public string CNPJ { get; set;}
    [Required, StringLength(128)]
    public string NomeFantasia { get ; set; }
    [StringLength(14)]
    public string TelefoneFixo { get ; set; }
    [Required, StringLength(14)]
    public string Celular { get; set; }
    [Required, StringLength(128)]
    public string RazaoSocial { get; set; }
    public double MediaAvaliacao { get; set; }
    public ICollection<Responsavel> Responsaveis { get; set; }
} 
