using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewerApp.Models;


public class Series{
    [Key]
    public int SeriesId { get; set; }
    public string? Title { get; set; }

    public string? Director { get; set; }

    public GenreType Genre { get; set; } 
}