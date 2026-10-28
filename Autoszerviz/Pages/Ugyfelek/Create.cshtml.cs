using Autoszerviz.Data;
using Autoszerviz.DTOs;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autoszerviz.Pages.Ugyfelek
{
    public class CreateModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public CreateModel(AutoszervizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UgyfelCreateDTO Ugyfel { get; set; } = new UgyfelCreateDTO();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ujUgyfel = new Ugyfel
            {
                Nev = Ugyfel.Nev.Trim(),
                Telefon = Ugyfel.Telefon,
                Email = Ugyfel.Email
            };

            _context.Ugyfelek.Add(ujUgyfel);
            await _context.SaveChangesAsync();

            TempData["Uzenet"] = $"{ujUgyfel.Nev} sikeresen hozzáadva.";
            return RedirectToPage("./Index");
        }
    }
}
