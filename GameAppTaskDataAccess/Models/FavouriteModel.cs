using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class FavouriteModel
    {
        [Key]
        public string Id { get; set; } = null!;

        [ForeignKey("UserId")]
        public string UserId { get; set; } = null!;
        public UserModel User { get; set; } = null!;

        [ForeignKey("BoardGameId")]
        public string BoardGameId { get; set; } = null!;
        public BoardGameModel BoardGame { get; set; } = null!;
    }
}
