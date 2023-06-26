using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using goblin_cheese.Areas.Identity.Data;

namespace goblin_cheese.Models.Game {

    public class Game {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Summary { get; set; }

        public string? CoverUrl { get; set; }
        public string? Opinion { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? ReleaseDate { get; set; }
        public List<Genre> Genre { get; } = new List<Genre>();
        public List<Screenshot> Screenshots { get; } = new List<Screenshot>();

        public List<GoblinUser> FavedBy { get; } = new List<GoblinUser>();
    }
}