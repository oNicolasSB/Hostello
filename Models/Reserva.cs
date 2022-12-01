using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Reserva 
{
    [Key]
    public int IdReserva { get; set; }
    public DateTime DataReserva { get; set; }
    public DateTime EstadiaEntrada { get; set; }
    public DateTime EstadiaSaida { get; set; }
    public double ValorReserva { get; set; }
    [ForeignKey("Cliente")]
    public int FkCliente { get; set; }
    public Cliente Cliente { get; set; }
} 
