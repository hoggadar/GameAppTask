using GameAppTaskDataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameAppTaskDataAccess.Models
{
    public class BoardGameModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public GenreEnum? Genre { get; set; }

        public int? GameTime { get; set; }

        public int? NumberPlayers { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public string? ImagePath { get; set; } = null!;
    }
}
