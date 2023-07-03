using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace goblin_cheese.Models.Movie;

[Table("Movie_Backdrop")]
public class Backdrop : Image.Image 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? Id {get;set;}
    public int? MovieId {get;set;}
    public Movie? Movie {get;set;}
    
}