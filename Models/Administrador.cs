using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Administrador : Usuario
{
    public ICollection<Avaliacao> Avaliacoes { get; set; }
    public ICollection<Acomodacao> Acomodacoes { get; set; }
}