using System.ComponentModel.DataAnnotations;

public class ImagemDeleteViewModel
{
    public int IdAcomodacao { get; set; }
    [Required]
    public string CaminhoImagem { get; set; }
}