using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Reserva 
{
    [Key]
    public int IdReserva { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime DataReserva { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime EstadiaEntrada { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public DateTime EstadiaSaida { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int QtdeDias { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public int QtdePessoas { get; set; }
    [(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public double ValorReserva { get; set; }
    [ForeignKey("Cliente")]
    public int FkCliente { get; set; }
    [ForeignKey("Acomodacao")]
    public int FkAcomodacao { get; set; }
    public Cliente Cliente { get; set; }
    public Acomodacao Acomodacao { get; set; }
} 
