using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Responsavel : Usuario
{
    [NotMapped]
    public ICollection<Estabelecimento> Estabelecimentos { get; set; }
}