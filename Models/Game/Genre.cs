using System.ComponentModel.DataAnnotations.Schema;

namespace goblin_cheese.Models.Game {

[Table("Game_Genre")]
    public class Genre {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Game> Games { get; } = new List<Game>();
    }

}