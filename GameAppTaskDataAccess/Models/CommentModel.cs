using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class CommentModel
    {
        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(50), MinLength(3)]
        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; } = null!;
        public UserModel User { get; set; } = null!;

        [ForeignKey("BoardGameId")]
        public string BoardGameId { get; set; } = null!;
        public BoardGameModel BoardGame { get; set; } = null!;

        [ForeignKey("ParentCommentId")]
        public string? ParentCommentId { get; set; }
        public CommentModel? ParentCommentModel { get; set; }
    }
}
