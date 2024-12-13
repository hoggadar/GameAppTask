using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class FavouriteModel
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; } = null!;

        [ForeignKey("BoardGameId")]
        public Guid BoardGameId { get; set; }
        public BoardGameModel BoardGame { get; set; } = null!;
    }
}
