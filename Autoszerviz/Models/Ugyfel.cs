using System.ComponentModel.DataAnnotations;

namespace Autoszerviz.Models
{
    public class Ugyfel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A név megadása kötelező.")]
        [MaxLength(100, ErrorMessage = "A név legfeljebb 100 karakter lehet.")]
        [Display(Name = "Név")]
        public string Nev { get; set; } = string.Empty;

        [MaxLength(20, ErrorMessage = "A telefonszám legfeljebb 20 karakter lehet.")]
        [Display(Name = "Telefonszám")]
        public string? Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Hibás e-mail cím formátum.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
    }
}
