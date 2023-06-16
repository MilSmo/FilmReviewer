using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FilmReviewerApp.Data;
using System;
using System.Linq;

namespace FilmReviewerApp.Models;
    public static class SeedReviews{
        public static void InitializeReviews(IServiceProvider serviceProvider){
            using (var context = new FilmReviewerAppContext(serviceProvider.GetRequiredService<DbContextOptions<FilmReviewerAppContext>>())){
                if (context.Review.Any()){
                    return;
                }
                
                context.Review.AddRange(
                    new Review() {ReviewId = 1, ReviewText = "Quite boring.", Rating = 5, FilmTitle = "Django", SeriesTitle = null, UserName = "User1"},
                    new Review() {ReviewId = 2, ReviewText = "Really interesting.", Rating = 4, FilmTitle = "Inception", SeriesTitle = null, UserName = "User2"},
                    new Review() {ReviewId = 3, ReviewText = "Outstanding plot!", Rating = 5, FilmTitle = "The Shawshank Redemption", SeriesTitle = null, UserName = "User3"},
                    new Review() {ReviewId = 4, ReviewText = "I didn't like it.", Rating = 2, FilmTitle = "Pulp Fiction", SeriesTitle = null, UserName = "User4"},
                    new Review() {ReviewId = 5, ReviewText = "I love it!", Rating = 5, FilmTitle = "The Godfather", SeriesTitle = null, UserName = "User5"},
                    new Review() {ReviewId = 6, ReviewText = "I didn't like it.", Rating = 2, FilmTitle = "The Dark Knight", SeriesTitle = null, UserName = "User6"},
                    new Review() {ReviewId = 7, ReviewText = "I love it!", Rating = 5, FilmTitle = "Fight Club", SeriesTitle = null, UserName = "User7"},
                    new Review() {ReviewId = 8, ReviewText = "I love it!", Rating = 5, FilmTitle = "The Matrix", SeriesTitle = null, UserName = "User8"},
                    new Review() {ReviewId = 9, ReviewText = "I love it!", Rating = 5, FilmTitle = "Forrest Gump", SeriesTitle = null, UserName = "User9"},
                    new Review() {ReviewId = 10, ReviewText = "I love it!", Rating = 5, FilmTitle = "Interstellar", SeriesTitle = null, UserName = "User10"},
                    new Review() {ReviewId = 11, ReviewText = "I love it!", Rating = 5, FilmTitle = null, SeriesTitle = "Breaking Bad", UserName = "User11"},
                    new Review() {ReviewId = 12, ReviewText = "I love it!", Rating = 5, FilmTitle = null, SeriesTitle = "Game of Thrones", UserName = "User12"},
                    new Review() {ReviewId = 13, ReviewText = "I love it!", Rating = 5, FilmTitle = null, SeriesTitle = "The Wire", UserName = "User13"},
                    new Review() {ReviewId = 14, ReviewText = "I love it!", Rating = 5, FilmTitle = null, SeriesTitle = "The Sopranos", UserName = "User14"},
                    new Review() {ReviewId = 15, ReviewText = "I love it!", Rating = 5, FilmTitle = null, SeriesTitle = "Sherlock", UserName = "User15"}
                );
                context.SaveChanges();
            }
        }
    }
    