﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly MovieTheatre.Data.MovieTheatreContext _context;

        public IndexModel(MovieTheatre.Data.MovieTheatreContext context)
        {
            _context = context;
        }

        public IList<Producer> Producer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Producer != null)
            {
                Producer = await _context.Producer.ToListAsync();
            }
        }
    }
}
