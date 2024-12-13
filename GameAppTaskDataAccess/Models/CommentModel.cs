using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class CommentModel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; } = null!;

        [ForeignKey("BoardGameId")]
        public Guid BoardGameId { get; set; }
        public BoardGameModel BoardGame { get; set; } = null!;

        [ForeignKey("ParentCommentId")]
        public Guid? ParentCommentId { get; set; }
        public CommentModel? ParentCommentModel { get; set; }
    }
}
