using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieTheatre.Models;

namespace MovieTheatre.Data
{
    public class MovieTheatreContext : DbContext
    {
        public MovieTheatreContext (DbContextOptions<MovieTheatreContext> options)
            : base(options)
        {
        }

        public DbSet<MovieTheatre.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MovieTheatre.Models.Producer> Producer { get; set; }

        public DbSet<MovieTheatre.Models.Category> Category { get; set; }
    }
}
