using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Aluguel
{
    [Key]
    public int IdAluguel { get; set; }
    public int QtdeDias { get; set; }
    public int QtdePessoas { get; set; }
    public double Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
    [ForeignKey("Acomodacao")]
    public int FkAcomodacao { get; set; }
    public Acomodacao Acomodacao { get; set; }

}