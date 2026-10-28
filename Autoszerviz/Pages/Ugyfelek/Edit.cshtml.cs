using Autoszerviz.Data;
using Autoszerviz.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autoszerviz.Pages.Ugyfelek
{
    public class EditModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public EditModel(AutoszervizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UgyfelEditDTO Ugyfel { get; set; } = new UgyfelEditDTO();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugyfel = await _context.Ugyfelek.FindAsync(id);
            if (ugyfel == null)
            {
                return NotFound();
            }

            Ugyfel = new UgyfelEditDTO
            {
                Id = ugyfel.Id,
                Nev = ugyfel.Nev,
                Telefon = ugyfel.Telefon,
                Email = ugyfel.Email
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ugyfel = await _context.Ugyfelek.FindAsync(Ugyfel.Id);
            if (ugyfel == null)
            {
                return NotFound();
            }

            ugyfel.Nev = Ugyfel.Nev.Trim();
            ugyfel.Telefon = Ugyfel.Telefon;
            ugyfel.Email = Ugyfel.Email;

            await _context.SaveChangesAsync();

            TempData["Uzenet"] = $"{ugyfel.Nev} adatai frissítve.";
            return RedirectToPage("./Index");
        }
    }
}
