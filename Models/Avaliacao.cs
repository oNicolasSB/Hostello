using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostello.Models;

public class Avaliacao 
{
    [Key]
    public int IdAvaliacao { get; set; }
    public DateTime? DataAvaliacao { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido.")]
    public double NotaAvaliacao { get; set; }
    [Required(ErrorMessage = "O campo {0} deve ser preenchido."), StringLength(256)]
    public string Comentario { get; set; }
    public bool? Aprovado { get; set; }
    [ForeignKey("Administrador")]
    public int? FkAdministrador { get; set; }
    [ForeignKey("Cliente")]
    public int FkCliente { get; set; }
    [ForeignKey("Acomodacao")]
    public int FkAcomodacao { get; set; }
    public Administrador Administrador { get; set; }
    public Cliente Cliente { get; set; }
    public Acomodacao Acomodacao { get; set; }
} 