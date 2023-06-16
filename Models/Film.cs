using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewerApp.Models;

public enum GenreType
{
    Fantasy, Science_Fiction, Mystery, Romance, Thriller, Horror, Historical_Fiction, Young_Adult, Adventure, Dystopian, Crime, Comedy, Biography, Self_help, Poetry, Non_fiction, Memoir, Suspense, Paranormal, Literary_Fiction, Action, Drama
}


public class Film{
    [Key]
    public int FilmId { get; set; }
    public string? Title { get; set; }

    public string? Director { get; set; }

    [EnumDataType(typeof(GenreType))]
    public GenreType? Genre { get; set; } 

}