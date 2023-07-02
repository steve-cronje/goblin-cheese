using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace goblin_cheese.Models.Movie;

public class Movie {

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id {get;set;}
    public string? Title {get;set;}
    public string? Overview {get;set;}
    [DataType(DataType.Date)]
    public DateOnly? ReleaseDate {get;set;}
    public int? Runtime {get;set;}
    public int? Budget {get;set;}
    public int? Revenue {get;set;}
    public Poster? Poster {get;set;}
    public IList<Backdrop> Backdrops {get;} = new List<Backdrop>();

}

