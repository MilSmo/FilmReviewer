using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FilmReviewerApp.Data;
using System;
using System.Linq;

namespace FilmReviewerApp.Models
{
    public static class SeedSeries
    {
        public static void InitializeSeries(IServiceProvider serviceProvider)
        {
            using (var context = new FilmReviewerAppContext(serviceProvider.GetRequiredService<DbContextOptions<FilmReviewerAppContext>>()))
            {
                if (context.Series.Any())
                {
                    return;
                }

                context.Series.AddRange(
                    new Series { SeriesId = 1, Title = "Breaking Bad", Director = "Vince Gilligan", Genre = GenreType.Drama },
                    new Series { SeriesId = 2, Title = "Game of Thrones", Director = "David Benioff, D.B. Weiss", Genre = GenreType.Fantasy },
                    new Series { SeriesId = 3, Title = "Friends", Director = "David Crane, Marta Kauffman", Genre = GenreType.Comedy },
                    new Series { SeriesId = 4, Title = "Stranger Things", Director = "The Duffer Brothers", Genre = GenreType.Drama },
                    new Series { SeriesId = 5, Title = "The Office", Director = "Greg Daniels, Ricky Gervais, Stephen Merchant", Genre = GenreType.Comedy },
                    new Series { SeriesId = 7, Title = "Sherlock", Director = "Mark Gatiss, Steven Moffat", Genre = GenreType.Crime },
                    new Series { SeriesId = 8, Title = "The Crown", Director = "Peter Morgan", Genre = GenreType.Drama },
                    new Series { SeriesId = 9, Title = "Stranger Things", Director = "The Duffer Brothers", Genre = GenreType.Drama },
                    new Series { SeriesId = 10, Title = "Peaky Blinders", Director = "Steven Knight", Genre = GenreType.Drama }
                );
                
                context.SaveChanges();
            }
        }
    }
}
