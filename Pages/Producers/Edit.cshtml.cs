﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTheatre.Data;
using MovieTheatre.Models;

namespace MovieTheatre.Pages.Producers
{
    public class EditModel : PageModel
    {
        private readonly MovieTheatre.Data.MovieTheatreContext _context;

        public EditModel(MovieTheatre.Data.MovieTheatreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producer Producer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producer == null)
            {
                return NotFound();
            }

            var producer =  await _context.Producer.FirstOrDefaultAsync(m => m.ID == id);
            if (producer == null)
            {
                return NotFound();
            }
            Producer = producer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Producer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducerExists(Producer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProducerExists(int id)
        {
          return _context.Producer.Any(e => e.ID == id);
        }
    }
}
