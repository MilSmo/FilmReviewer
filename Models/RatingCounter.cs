using FilmReviewerApp.Controllers;
using FilmReviewerApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FilmReviewerApp.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FilmReviewerApp.Models;

public class RatingCounter
{
    public static Dictionary<string, int> Films_Avg { get; } = new Dictionary<string, int>();
    
    public static void CountRatings(IServiceProvider serviceProvider)
    {
        using (var context =
               new FilmReviewerAppContext(
                   serviceProvider.GetRequiredService<DbContextOptions<FilmReviewerAppContext>>()))
        {
            ReviewController reviewController = new ReviewController(context); // Pass the appropriate FilmReviewerAppContext instance
            Dictionary<string, int> filmsRatings = reviewController.Films_Ratings;

// Access the filmsRatings dictionary as needed
            foreach (var movie in filmsRatings.Keys)
            {
                List<int> ratings = new List<int>();
                int sum = 0;
                for(int i=0; i< filmsRatings.Count; i++)
                {
                    if (filmsRatings.Keys.ElementAt(i) == movie)
                    {
                        ratings.Add(filmsRatings.Values.ElementAt(i));
                        sum += filmsRatings.Values.ElementAt(i);
                    }
                }
                int rating = sum / ratings.Count;
                if (Films_Avg.ContainsKey(movie))
                {
                    int result = Films_Avg[movie];
                    Films_Avg[movie] = result + rating / 2;
                }
                else
                {
                    Films_Avg.Add(movie, rating);
                }
            }


            context.SaveChanges();
        }
    }
}