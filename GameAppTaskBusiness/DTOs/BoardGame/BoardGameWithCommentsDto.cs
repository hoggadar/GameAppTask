using GameAppTaskBusiness.DTOs.Comment;

namespace GameAppTaskBusiness.DTOs.BoardGame
{
    public class BoardGameWithCommentsDto : BoardGameBase
    {
        public string Id { get; set; } = null!;
        public List<CommentWithUserDto> Comments { get; set; } = new List<CommentWithUserDto>();
    }
}
