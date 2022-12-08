using System.ComponentModel.DataAnnotations;

public class PagamentoViewModel
{
    [Display(Name = "Nome no Cartão")]
    [Required(ErrorMessage ="O campo {0} deve ser preenchido.")]
    public string Nome { get; set; }
    [Display(Name = "Número do Cartão")]
    [Required(ErrorMessage ="O campo {0} deve ser preenchido.")]
    public string Numero { get; set; }
    [Display(Name = "Validade do Cartão")]
    [Required(ErrorMessage ="O campo {0} deve ser preenchido.")]
    public string Validade { get; set; }
    [Display(Name = "CVC/CVV do Cartão")]
    [Required(ErrorMessage ="O campo {0} deve ser preenchido.")]
    public int CVC { get; set; }
    public int FkReserva { get; set; }

}