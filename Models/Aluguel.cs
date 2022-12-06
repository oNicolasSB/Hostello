using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Aluguel
{
    [Key]
    public int IdAluguel { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int QtdeDias { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int QtdePessoas { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public double Valor { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime DataEntrada { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime DataSaida { get; set; }
    [ForeignKey("Acomodacao")]
    public int FkAcomodacao { get; set; }
    public Acomodacao Acomodacao { get; set; }

}