using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class TipoAcomodacao
{
    [Key]
    public int IdTipoAcomodacao { get; set; }
    [Required, StringLength(64)]
    public string NomeAcomodacao { get; set; }
    public ICollection<Acomodacao> Acomodacoes { get; set; }
}