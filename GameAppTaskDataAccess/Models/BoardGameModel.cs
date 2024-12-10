using GameAppTaskDataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameAppTaskDataAccess.Models
{
    public class BoardGameModel
    {
        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(50), MinLength(3)]
        public string Title { get; set; } = null!;
        
        [MaxLength(256)]
        public string Description { get; set; } = null!;

        public GenreEnum? Genre { get; set; }

        public int? GameTime { get; set; }

        public int? NumberPlayers { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public string? ImagePath { get; set; } = null!;

        public ICollection<FavouriteModel> Favourites { get; set; } = null!;
        public ICollection<CommentModel> Comments { get; set; } = null!;
    }
}
