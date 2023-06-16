using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewerApp.Models;

public class Review{
    [Key]
    public int? ReviewId { get; set; }

    public string ReviewText { get; set; } = null!;

    public int Rating { get; set; }

    public string? FilmTitle { get; set; } = null!;

    public string? SeriesTitle { get; set; } = null!;

    public string? UserName { get; set; }
}