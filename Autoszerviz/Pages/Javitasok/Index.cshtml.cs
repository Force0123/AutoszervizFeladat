using Autoszerviz.Data;
using Autoszerviz.Models;
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

        public async Task OnGetAsync()
        {
            Javitasok = await _context.Javitasok
                .Include(j => j.Ugyfel)
                .OrderByDescending(j => j.FelvetelDatuma)
                .ToListAsync();
        }
    }
}
