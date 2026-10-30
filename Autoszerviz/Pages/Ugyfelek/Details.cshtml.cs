using Autoszerviz.Data;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Ugyfelek
{
    public class DetailsModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public DetailsModel(AutoszervizContext context)
        {
            _context = context;
        }

        public Ugyfel Ugyfel { get; set; } = default!;

        public List<Javitas> Javitasok { get; set; } = new List<Javitas>();

        public decimal Osszkoltseg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugyfel = await _context.Ugyfelek
                .Include(u => u.Javitasok)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (ugyfel == null)
            {
                return NotFound();
            }

            Ugyfel = ugyfel;
            Javitasok = ugyfel.Javitasok.OrderByDescending(j => j.FelvetelDatuma).ToList();

            Osszkoltseg = 0;
            foreach (var javitas in Javitasok)
            {
                if (javitas.Koltseg != null)
                {
                    Osszkoltseg += javitas.Koltseg.Value;
                }
            }

            return Page();
        }
    }
}
