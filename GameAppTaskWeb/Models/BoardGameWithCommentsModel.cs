using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.DTOs.Comment;

namespace GameAppTaskWeb.Models
{
    public class BoardGameWithCommentsModel
    {
        public BoardGameDto BoardGame { get; set; } = null!;
        public IEnumerable<CommentDto> Comments { get; set; } = null!;
    }
}
