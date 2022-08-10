using System;
using System.ComponentModel.DataAnnotations;

namespace hostello.Models;

public class Avaliacao 
{
    [Key]
    public int IdAvaliacao { get; set; }
    public DateTime DataAvaliacao { get; set; }
    public double NotaAvaliacao { get; set; }
    [Required, StringLength(256)]
    public string Comentario { get; set; }
} 