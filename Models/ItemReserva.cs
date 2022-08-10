using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class ItemReserva
{
    [Key]
    public int IdItemReserva { get; set; }
    [Required]
    public double Valor { get; set; }
}