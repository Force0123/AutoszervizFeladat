using Autoszerviz.Data;
using Autoszerviz.DTOs;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Javitasok
{
    public class CreateModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public CreateModel(AutoszervizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JavitasCreateDTO Javitas { get; set; } = new JavitasCreateDTO();

        public SelectList UgyfelLista { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
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

            var ujJavitas = new Javitas
            {
                UgyfelId = Javitas.UgyfelId!.Value,
                Rendszam = Javitas.Rendszam,
                Leiras = Javitas.Leiras,
                Koltseg = Javitas.Koltseg,
                Allapot = "Felvéve",
                FelvetelDatuma = DateTime.Now
            };

            _context.Javitasok.Add(ujJavitas);
            await _context.SaveChangesAsync();

            TempData["Uzenet"] = $"A(z) {ujJavitas.Rendszam} javítás felvéve.";
            return RedirectToPage("./Index");
        }

        private async Task UgyfelekBetoltese()
        {
            var ugyfelek = await _context.Ugyfelek.OrderBy(u => u.Nev).ToListAsync();
            UgyfelLista = new SelectList(ugyfelek, "Id", "Nev");
        }
    }
}
