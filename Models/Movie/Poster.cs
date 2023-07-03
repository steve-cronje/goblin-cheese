using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goblin_cheese.Models.Movie;

[Table("Movie_Poster")]
public class Poster : Image.Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? Id{get;set;}
    public int? MovieId {get;set;}
    public Movie? Movie {get;set;}
}