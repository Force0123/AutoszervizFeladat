using Autoszerviz.Data;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Javitasok
{
    public class IndexModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public IndexModel(AutoszervizContext context)
        {
            _context = context;
        }

        public IList<Javitas> Javitasok { get; set; } = new List<Javitas>();

        [BindProperty(SupportsGet = true)]
        public string? AllapotSzuro { get; set; }

        public async Task OnGetAsync()
        {
            var lekerdezes = _context.Javitasok
                .Include(j => j.Ugyfel)
                .AsQueryable();

            if (!string.IsNullOrEmpty(AllapotSzuro))
            {
                lekerdezes = lekerdezes.Where(j => j.Allapot == AllapotSzuro);
            }

            Javitasok = await lekerdezes
                .OrderByDescending(j => j.FelvetelDatuma)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostLeptetAsync(int id)
        {
            var javitas = await _context.Javitasok.FindAsync(id);
            if (javitas == null)
            {
                return NotFound();
            }

            if (javitas.Allapot == "Felvéve")
            {
                javitas.Allapot = "Folyamatban";
            }
            else if (javitas.Allapot == "Folyamatban")
            {
                if (javitas.Koltseg == null || javitas.Koltseg <= 0)
                {
                    TempData["Hiba"] = $"A(z) {javitas.Rendszam} javítás csak akkor lehet kész, ha meg van adva a költség.";
                    return RedirectToPage(new { AllapotSzuro });
                }

                javitas.Allapot = "Kész";
            }

            await _context.SaveChangesAsync();
            TempData["Uzenet"] = $"A(z) {javitas.Rendszam} javítás új állapota: {javitas.Allapot}.";

            return RedirectToPage(new { AllapotSzuro });
        }
    }
}
