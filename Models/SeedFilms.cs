using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FilmReviewerApp.Data;
using System;
using System.Linq;

namespace FilmReviewerApp.Models;
    public static class SeedFilms{
        public static void InitializeFilms(IServiceProvider serviceProvider){
            using (var context = new FilmReviewerAppContext(serviceProvider.GetRequiredService<DbContextOptions<FilmReviewerAppContext>>())){
                if (context.Film.Any()){
                    return;
                }
                
                context.Film.AddRange(
                    new Film(){FilmId = 1, Title = "Django", Director = "Quentin Tarantino", Genre = GenreType.Adventure},
                    new Film { FilmId = 2, Title = "Inception", Director = "Christopher Nolan", Genre = GenreType.Action },
                    new Film { FilmId = 3, Title = "The Shawshank Redemption", Director = "Frank Darabont", Genre = GenreType.Drama },
                    new Film { FilmId = 4, Title = "Pulp Fiction", Director = "Quentin Tarantino", Genre = GenreType.Crime },
                    new Film { FilmId = 5, Title = "The Godfather", Director = "Francis Ford Coppola", Genre = GenreType.Crime },
                    new Film { FilmId = 6, Title = "The Dark Knight", Director = "Christopher Nolan", Genre = GenreType.Action },
                    new Film { FilmId = 7, Title = "Fight Club", Director = "David Fincher", Genre = GenreType.Drama },
                    new Film { FilmId = 8, Title = "The Matrix", Director = "The Wachowskis", Genre = GenreType.Action },
                    new Film { FilmId = 9, Title = "Forrest Gump", Director = "Robert Zemeckis", Genre = GenreType.Drama },
                    new Film { FilmId = 10, Title = "Interstellar", Director = "Christopher Nolan", Genre = GenreType.Science_Fiction }

                );
                context.SaveChanges();
            }
        }
    }
    