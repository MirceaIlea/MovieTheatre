using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieTheatre.Data;
using MovieTheatre.Models;

namespace MovieTheatre.Pages.Producers
{
    public class DeleteModel : PageModel
    {
        private readonly MovieTheatre.Data.MovieTheatreContext _context;

        public DeleteModel(MovieTheatre.Data.MovieTheatreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Producer Producer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producer == null)
            {
                return NotFound();
            }

            var producer = await _context.Producer.FirstOrDefaultAsync(m => m.ID == id);

            if (producer == null)
            {
                return NotFound();
            }
            else 
            {
                Producer = producer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Producer == null)
            {
                return NotFound();
            }
            var producer = await _context.Producer.FindAsync(id);

            if (producer != null)
            {
                Producer = producer;
                _context.Producer.Remove(Producer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
