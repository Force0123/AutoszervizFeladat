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
    }
}
