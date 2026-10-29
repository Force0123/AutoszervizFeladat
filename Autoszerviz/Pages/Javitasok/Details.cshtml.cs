using Autoszerviz.Data;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Javitasok
{
    public class DetailsModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public DetailsModel(AutoszervizContext context)
        {
            _context = context;
        }

        public Javitas Javitas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var javitas = await _context.Javitasok
                .Include(j => j.Ugyfel)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (javitas == null)
            {
                return NotFound();
            }

            Javitas = javitas;
            return Page();
        }
    }
}
