using System.ComponentModel.DataAnnotations;

namespace GameAppTaskBusiness.DTOs.BoardGame
{
    public class BoardGameBase
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Genre { get; set; }

        public int? GameTime { get; set; }

        public int? NumberPlayers { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public string? ImagePath { get; set; }
    }
}
