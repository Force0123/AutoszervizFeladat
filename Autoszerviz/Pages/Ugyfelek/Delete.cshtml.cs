using Autoszerviz.Data;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Ugyfelek
{
    public class DeleteModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public DeleteModel(AutoszervizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ugyfel Ugyfel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugyfel = await _context.Ugyfelek.FirstOrDefaultAsync(u => u.Id == id);
            if (ugyfel == null)
            {
                return NotFound();
            }

            Ugyfel = ugyfel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugyfel = await _context.Ugyfelek.FindAsync(id);
            if (ugyfel != null)
            {
                _context.Ugyfelek.Remove(ugyfel);
                await _context.SaveChangesAsync();
                TempData["Uzenet"] = $"{ugyfel.Nev} törölve.";
            }

            return RedirectToPage("./Index");
        }
    }
}
