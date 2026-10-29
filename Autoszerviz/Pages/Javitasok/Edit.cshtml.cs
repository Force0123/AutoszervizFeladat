using Autoszerviz.Data;
using Autoszerviz.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Javitasok
{
    public class EditModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public EditModel(AutoszervizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JavitasEditDTO Javitas { get; set; } = new JavitasEditDTO();

        public SelectList UgyfelLista { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var javitas = await _context.Javitasok.FindAsync(id);
            if (javitas == null)
            {
                return NotFound();
            }

            Javitas = new JavitasEditDTO
            {
                Id = javitas.Id,
                UgyfelId = javitas.UgyfelId,
                Rendszam = javitas.Rendszam,
                Leiras = javitas.Leiras,
                Koltseg = javitas.Koltseg
            };

            await UgyfelekBetoltese();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await UgyfelekBetoltese();
                return Page();
            }

            var javitas = await _context.Javitasok.FindAsync(Javitas.Id);
            if (javitas == null)
            {
                return NotFound();
            }

            javitas.UgyfelId = Javitas.UgyfelId!.Value;
            javitas.Rendszam = Javitas.Rendszam;
            javitas.Leiras = Javitas.Leiras;
            javitas.Koltseg = Javitas.Koltseg;

            await _context.SaveChangesAsync();

            TempData["Uzenet"] = $"A(z) {javitas.Rendszam} javítás módosítva.";
            return RedirectToPage("./Index");
        }

        private async Task UgyfelekBetoltese()
        {
            var ugyfelek = await _context.Ugyfelek.OrderBy(u => u.Nev).ToListAsync();
            UgyfelLista = new SelectList(ugyfelek, "Id", "Nev");
        }
    }
}
