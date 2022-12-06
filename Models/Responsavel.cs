using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Responsavel : Usuario
{
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(14)]
    public string CNPJ { get; set;}
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(128)]
    public string NomeFantasia { get ; set; }
    [StringLength(14), (ErrorMessage = "O campo {0} deve ser preenchido.")]
    public string Celular { get ; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(14)]
    public string RazaoSocial { get; set; }
    public double? MediaAvaliacao { get; set; }
    [ForeignKey("Endereco")]
    public int? FkEndereco { get; set; }
    public Endereco Endereco { get; set; }
    public ICollection<Acomodacao> Acomodacoes { get; set; }
    public ICollection<Contato> Contatos { get; set; }
}