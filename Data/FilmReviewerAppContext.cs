using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmReviewerApp.Models;

namespace FilmReviewerApp.Data
{
    public class FilmReviewerAppContext : DbContext
    {
        public FilmReviewerAppContext (DbContextOptions<FilmReviewerAppContext> options)
            : base(options)
        {
        }

        public DbSet<FilmReviewerApp.Models.User> User { get; set; } = default!;

        public DbSet<FilmReviewerApp.Models.Film> Film { get; set; } = default!;

        public DbSet<FilmReviewerApp.Models.Series> Series { get; set; } = default!;

        public DbSet<FilmReviewerApp.Models.Review> Review { get; set; } = default!;
    }
}
