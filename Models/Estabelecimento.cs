using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public double? MediaAvaliacao { get; set; }
    [ForeignKey("Endereco")]
    public int? FkEndereco { get; set; }
    public Endereco Endereco { get; set; }
    public ICollection<Acomodacao> Acomodacoes { get; set; }
    public ICollection<Contato> Contatos { get; set; }
} 
