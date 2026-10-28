using Autoszerviz.Data;
using Autoszerviz.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Pages.Ugyfelek
{
    public class IndexModel : PageModel
    {
        private readonly AutoszervizContext _context;

        public IndexModel(AutoszervizContext context)
        {
            _context = context;
        }

        public IList<Ugyfel> Ugyfelek { get; set; } = new List<Ugyfel>();

        public async Task OnGetAsync()
        {
            Ugyfelek = await _context.Ugyfelek
                .OrderBy(u => u.Nev)
                .ToListAsync();
        }
    }
}
