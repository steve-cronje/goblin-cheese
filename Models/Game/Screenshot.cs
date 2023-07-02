using System.ComponentModel.DataAnnotations.Schema;

namespace goblin_cheese.Models.Game {

    [Table("Game_Screenshot")]
    public class Screenshot {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? ImageUrl { get; set; }
    
        public Game? Game { get; set; }
    }
}