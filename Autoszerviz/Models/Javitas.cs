using System.ComponentModel.DataAnnotations;

namespace Autoszerviz.Models
{
    public class Javitas
    {
        public int Id { get; set; }

        [Display(Name = "Ügyfél")]
        public int UgyfelId { get; set; }

        [Display(Name = "Ügyfél")]
        public Ugyfel? Ugyfel { get; set; }

        [Required(ErrorMessage = "A rendszám megadása kötelező.")]
        [MaxLength(10, ErrorMessage = "A rendszám legfeljebb 10 karakter lehet.")]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{3}$", ErrorMessage = "A rendszám formátuma: ABC-123")]
        [Display(Name = "Rendszám")]
        public string Rendszam { get; set; } = string.Empty;

        [MaxLength(300, ErrorMessage = "A leírás legfeljebb 300 karakter lehet.")]
        [Display(Name = "Leírás")]
        public string? Leiras { get; set; }

        [Display(Name = "Költség (Ft)")]
        public decimal? Koltseg { get; set; }

        [Display(Name = "Állapot")]
        public string Allapot { get; set; } = "Felvéve";

        [Display(Name = "Felvétel dátuma")]
        [DataType(DataType.Date)]
        public DateTime FelvetelDatuma { get; set; }
    }
}
