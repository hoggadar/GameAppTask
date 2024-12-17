namespace GameAppTaskBusiness.DTOs.Comment
{
    public class CommentBase
    {
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = null!;
        public string BoardId { get; set; } = null!;
        public string ParentCommentId { get; set; } = null!;
    }
}
