using System.ComponentModel.DataAnnotations.Schema;

namespace goblin_cheese.Models;

[Table("TV_Genre")]
public class TVGenre {

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public IList<Movie.Movie> Movies { get; } = new List<Movie.Movie>();
}