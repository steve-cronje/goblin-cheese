using System.ComponentModel.DataAnnotations.Schema;

namespace goblin_cheese.Models.Game {

    public class Screenshot {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? ImageUrl { get; set; }
    
        public Game? Game { get; set; }
    }
}