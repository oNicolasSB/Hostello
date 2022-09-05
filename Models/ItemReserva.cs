using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class ItemReserva
{
    [Key]
    public int IdItemReserva { get; set; }
    [Required]
    public double Valor { get; set; }
    [ForeignKey("Acomodacao")]
    public int FkAcomodacao { get; set; }
    [ForeignKey("Reserva")]
    public int FkReserva { get; set; }
    public Acomodacao Acomodacao { get; set; }
    public Reserva Reserva { get; set; }
}