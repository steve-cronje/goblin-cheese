using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace goblin_cheese.Models.Movie;

public class Movie
{

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? ReleaseDate { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? DateAdded { get; set; }
    public double? Runtime { get; set; }
    public double? Budget { get; set; }
    public double? Revenue { get; set; }
    public Poster? Poster { get; set; }
    public IList<Backdrop> Backdrops { get; } = new List<Backdrop>();
    public IList<TVGenre> Genres { get; } = new List<TVGenre>();

}

