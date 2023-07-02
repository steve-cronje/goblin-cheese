using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goblin_cheese.Models.Movie;

[Table("Movie_Poster")]
public class Poster : Image.Image
{
    [Key]
    [ForeignKey("Movie")]
    public int MovieId {get;set;}
    public Movie? Movie {get;set;}
}