using System.ComponentModel.DataAnnotations;

namespace Autoszerviz.DTOs
{
    public class JavitasCreateDTO
    {
        [Required(ErrorMessage = "Válassz ügyfelet.")]
        [Display(Name = "Ügyfél")]
        public int? UgyfelId { get; set; }

        [Required(ErrorMessage = "A rendszám megadása kötelező.")]
        [MaxLength(10, ErrorMessage = "A rendszám legfeljebb 10 karakter lehet.")]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{3}$", ErrorMessage = "A rendszám formátuma: ABC-123")]
        [Display(Name = "Rendszám")]
        public string Rendszam { get; set; } = string.Empty;

        [MaxLength(300, ErrorMessage = "A leírás legfeljebb 300 karakter lehet.")]
        [Display(Name = "Leírás")]
        public string? Leiras { get; set; }

        [Range(0, 10000000, ErrorMessage = "A költség nem lehet negatív.")]
        [Display(Name = "Költség (Ft)")]
        public decimal? Koltseg { get; set; }
    }
}
